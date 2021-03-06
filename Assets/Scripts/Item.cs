﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	// Smooth push
	[Header("Smooth push")]
	public float floatFactor = 0.98f;
	[HideInInspector]
	public Rigidbody2D rigidbody2d;
	private bool collided;

	[Header("Item pickable")]
	public GameObject objectPrefab;
	public float range = 1.2f;
	SpriteRenderer sprite;
	bool canPickUp = false;

	[Header("Stack")]
	public bool isStack;
	public int maxItems = 6;
	public float respawnTime = 6;
	public Text leftText;
	public Animator animatorUi;
	

	// Internal
	int itemsRemaning = 6;
	float timeSinceLastSpawn;


	void Awake() {
		itemsRemaning = maxItems;
		rigidbody2d = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update() {
		// Smooth push
		if (!collided && !isStack) {
			rigidbody2d.velocity *= floatFactor;
			rigidbody2d.angularVelocity *= floatFactor;
		}

		// PickingUp
		canPickUp = Vector3.Distance(transform.position, GameManager.instance.player.transform.position) <= range;
		if (canPickUp) {
			if (itemsRemaning > 0)
				Inventory.CheckIfCanHighlight(this);
		} else {
			Inventory.DeHighlight(this);
		}

		if (isStack) {
			if (Time.timeSinceLevelLoad - timeSinceLastSpawn >= respawnTime && itemsRemaning < maxItems) {
				itemsRemaning += 1;
				timeSinceLastSpawn = Time.timeSinceLevelLoad;
				animatorUi.SetTrigger("Grab");
			}
			leftText.text = "<b>" + itemsRemaning.ToString() + "</b>";
		}

	}

	public void Highlight() {
		//sprite.color = Color.black;
		GetComponent<SpriteOutline>().outlineSize = 4;
	}

	public void DeHighlight() {
		//sprite.color = Color.white;
		GetComponent<SpriteOutline>().outlineSize = 0;
	}

	public Item Pickup() {
		if (isStack) {
			GameObject tempGo = Instantiate(objectPrefab, GameManager.instance.player.GetComponent<PlayerControls>().itemSpawn.transform);
			Item item = tempGo.GetComponent<Item>();
			item.rigidbody2d.simulated = false;
			item.sprite.sortingOrder = 100;
			tempGo.transform.rotation = new Quaternion();
			tempGo.transform.localPosition = Vector3.zero;
			itemsRemaning -= 1;
			animatorUi.SetTrigger("Grab");
			if (!(itemsRemaning + 1 < maxItems))
				timeSinceLastSpawn = Time.timeSinceLevelLoad;
			return item;
		} else {
			rigidbody2d.simulated = false;
			sprite.sortingOrder = 100;
			transform.SetParent(GameManager.instance.player.GetComponent<PlayerControls>().itemSpawn.transform);
			transform.rotation = new Quaternion();
			transform.localPosition = Vector3.zero;
			return this;
		}
	}

	public void Drop() {
		rigidbody2d.simulated = true;
		sprite.sortingOrder = 0;
		rigidbody2d.velocity = GameManager.instance.player.GetComponent<PlayerControls>().lastMoveNon0 * 6;
		if (GameManager.instance.player.GetComponent<PlayerControls>().move != Vector2.zero)
			rigidbody2d.velocity *= 2;
		rigidbody2d.velocity = Helpers.StretchXVelocity(rigidbody2d.velocity);
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

	private void OnTriggerEnter2D( Collider2D collision )
	{
		if( collision.tag == "Destroyer" )
		{
			StartCoroutine( FadeOutAndDestroy() );
		}
	}

	IEnumerator FadeOutAndDestroy()
	{
		Color c;
		float duration = .1f;
		for( float ft = 1f; ft >= 0f; ft -= Time.deltaTime / duration )
		{
			c = sprite.material.color;
			c.a = ft;
			sprite.material.color = c;
			yield return null;
		}
		Destroy( gameObject );
	}
}

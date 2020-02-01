using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	// Smooth push
	[Header("Smooth push")]
	public float floatFactor = 0.98f;
	[HideInInspector]
	public Rigidbody2D rigidbody2d;
	private bool collided;

	[Header("Item pickable")]
	public bool isStack;
	public GameObject objectPrefab;
	public int itemsRemaning = 5;
	SpriteRenderer sprite;
	bool canPickUp = false;
    

	void Awake() {
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
		canPickUp = Vector3.Distance(transform.position, GameManager.instance.player.transform.position) <= 1.2f;
		if (canPickUp) {
			Inventory.CheckIfCanHighlight(this);
		} else {
			Inventory.DeHighlight(this);
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
   
    
}

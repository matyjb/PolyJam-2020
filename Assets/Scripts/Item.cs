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
	public bool pickable;
	SpriteRenderer sprite;
	bool canPickUp = false;
    

	void Awake() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update() {
		// Smooth push
		if (!collided) {
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

		Pickup();
	}

	public void Highlight() {
		sprite.color = Color.black;
	}

	public void DeHighlight() {
		sprite.color = Color.white;
	}

	void Pickup() {
		if (Inventory.currentHighlited == this && Input.GetKeyDown(KeyCode.F)) {
			rigidbody2d.simulated = false;
			sprite.sortingOrder = 100;
			transform.SetParent(GameManager.instance.player.GetComponent<PlayerControls>().itemSpawn.transform);
			transform.localPosition = Vector3.zero;
			Inventory.Pickup(this);
		}
	}

	public void Drop() {
		rigidbody2d.simulated = true;
		sprite.sortingOrder = 0;
		rigidbody2d.velocity = GameManager.instance.player.GetComponent<PlayerControls>().lastMoveNon0 * 8;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Item currentHighlited;
	public static Item pickedUp;

	public GameObject draggables;

	public static void Pickup(Item item) {
		pickedUp = item;
		DeHighlight(item);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Fire1")) {
			if (pickedUp == null) {
				if (currentHighlited != null) {
					Item item = currentHighlited.Pickup();
					Pickup(item);
					GameManager.instance.player.GetComponent<PlayerControls>().ChangeHolding(true);
				}
			} else {
				// Drop
				pickedUp.transform.SetParent(draggables.transform);
				pickedUp.transform.position = GameManager.instance.player.transform.position + (Vector3)GameManager.instance.player.GetComponent<PlayerControls>().lastMoveNon0;
				pickedUp.Drop();
				pickedUp = null;
				GameManager.instance.player.GetComponent<PlayerControls>().ChangeHolding(false);
			}
		}
	}

	public static void CheckIfCanHighlight(Item item) {
		if (currentHighlited == null && pickedUp == null) {
			currentHighlited = item;
			item.Highlight();
		}
	}

	public static void DeHighlight(Item item) {
		if (currentHighlited == item) {
			item.DeHighlight();
			currentHighlited = null;
		}
	}
}

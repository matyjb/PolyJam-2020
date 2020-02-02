using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBottleCollision : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Bottle") {
			Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
		}

	}
}

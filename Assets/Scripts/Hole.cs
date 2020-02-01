using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
	public bool fixedHole;
	public bool walkable;

	SpriteRenderer spriteRenderer;
	public Sprite holeSprite;
	public Sprite fixedHoleSprite;

	CircleCollider2D collider;


	void Start()
	{
		fixedHole = false;

		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = holeSprite;

		collider = GetComponent<CircleCollider2D>();
	}

	private void OnCollisionEnter2D( Collision2D collision )
	{
		if( !fixedHole )
		{
			if( collision.gameObject.CompareTag( "FixingPlank" ) )
			{
				Destroy( collision.gameObject );
				Fix();
			}
		}
	}

	public void Fix()
	{
		fixedHole = true;
		spriteRenderer.sprite = fixedHoleSprite;
		collider.enabled = false;
		GameManager.instance.DamageShip( -0.1f );
	}

	public void Break()
	{
		fixedHole = false;
		spriteRenderer.sprite = holeSprite;
		collider.enabled = true;
	}
}

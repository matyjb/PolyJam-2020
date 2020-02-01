using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
	enum State {
		mark,
		hole,
		fixedHole
	}
	State state;

	SpriteRenderer spriteRenderer;
	public Sprite xMarkSprite;
	public Sprite holeSprite;
	public Sprite fixedHoleSprite;

	CircleCollider2D collider;


	void Start()
	{
		state = State.mark;

		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = xMarkSprite;

		collider = GetComponent<CircleCollider2D>();
		collider.enabled = false;

		StartCoroutine( CannonballHit() );
	}

	private void OnCollisionEnter2D( Collision2D collision )
	{
		if( state == State.hole )
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
		state = State.fixedHole;
		spriteRenderer.sprite = fixedHoleSprite;
		collider.enabled = false;
		GameManager.instance.DamageShip( -0.1f );
	}

	public void Break()
	{
		state = State.hole;
		spriteRenderer.sprite = holeSprite;
		collider.enabled = true;
		GameManager.instance.DamageShip( .1f );
	}

	IEnumerator CannonballHit()
	{
		float timeToImpact = Random.Range( 4f, 6f );

		for( float ft = 0; ft < 1; ft += Time.deltaTime / timeToImpact )
		{
			Color c = spriteRenderer.material.color;
			c.a = ft;
			spriteRenderer.material.color = c;
			yield return null;
		}

		for( int i = 0; i < 3; ++i )
		{
			for( float ft = 3f; ft >= .5f; ft -= Time.deltaTime * 3 )
			{
				Color c = spriteRenderer.material.color;
				c.a = ft;
				spriteRenderer.material.color = c;
				yield return null;
			}
		}

		Break();
	}
}

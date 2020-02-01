using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

	[Header("Speed")]
    public float speedFactorX = 2;
    public float speedFactorY = 1;
    public bool isRaw = true;
	[HideInInspector]
	public Vector2 lastMoveNon0 = Vector2.right;
	[HideInInspector]
	public Vector2 move;

	[Header("Item")]
	public GameObject itemSpawn;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 speed = new Vector2(speedFactorX, speedFactorY);
        if (isRaw)
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }
        rigidbody2d.MovePosition(move * Time.fixedDeltaTime * speed * 5 + rigidbody2d.position);
		if (move != Vector2.zero) {
			lastMoveNon0 = move;
		}
    }
}

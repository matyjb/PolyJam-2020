using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float speedFactorX = 2;
    public float speedFactorY = 1;
    public bool isRaw = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 speed = new Vector2(speedFactorX, speedFactorY);
        Vector2 move;
        if (isRaw)
        {
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        else
        {
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }
        rigidbody2d.MovePosition(move * Time.fixedDeltaTime * speed * 5 + rigidbody2d.position);
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.tag == "StairsDown" )
            transform.position = new Vector3( -6.79f, -21.5f, -1 );
        else if( collision.tag == "StairsUp" )
            transform.position = new Vector3( -4.19f, 2.07f, -1 );
    }
}


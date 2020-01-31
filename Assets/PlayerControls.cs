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
    void Update()
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
        rigidbody2d.velocity = move * Time.deltaTime * speed * 1000;
    }
}

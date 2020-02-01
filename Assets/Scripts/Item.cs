using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float floatFactor = 0.98f;
    private bool collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(collided);
        if (!collided)
        {
            rigidbody2d.velocity *= floatFactor;
            rigidbody2d.angularVelocity *= floatFactor;
        }
    }
}

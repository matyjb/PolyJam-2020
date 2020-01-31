using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float floatFactor = 0.80f;
    private bool isCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isCollided);
        if (!isCollided)
        {

        rigidbody2d.velocity *= floatFactor;
        rigidbody2d.angularVelocity *= floatFactor;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollided = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollided = false;
    }
}

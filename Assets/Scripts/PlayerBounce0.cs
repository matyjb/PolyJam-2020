using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

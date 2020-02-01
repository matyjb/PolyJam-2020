using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonGuyPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CanonBall")
        {
            canon.GetComponentInChildren<BurstTrigger>().FireCanon();
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToUnder : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position += new Vector3(12.7f, -20.8f, 0);
        //GameObject.Find("Camera").transform.position += new Vector3(0, -20, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

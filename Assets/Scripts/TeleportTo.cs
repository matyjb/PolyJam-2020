using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    public GameObject TeleportLocation;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = TeleportLocation.transform.position - new Vector3(0,0,TeleportLocation.transform.position.z);

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

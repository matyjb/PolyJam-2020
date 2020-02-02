using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && Time.timeScale == 0 && !GameManager.instance.IsShipDead )
        {
            GetComponent<Animator>().SetTrigger("Start");
            Time.timeScale = 1;
            GameManager.instance.StartTime();
        }
    }
}

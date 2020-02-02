using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelControl : MonoBehaviour
{
    public static WaterLevelControl _instance;
    public void Awake()
    {
        _instance = this;    
    }
    
    private bool isInsideWater = false;
    private WaterLevel wl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
            isInsideWater = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            isInsideWater = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        wl = GetComponent<WaterLevel>();
    }

    // Update is called once per frame
    public void PickUpBucketOfWater()
    {
        if (isInsideWater && (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.F)))
        {
            wl.WaterLevelPercent -= 0.3f;
            GetComponent<AudioSource>().Play();
            if (wl.WaterLevelPercent < 0) wl.WaterLevelPercent = 0;
        }
    }
    public void FailThrowWaterOut()
    {
        wl.WaterLevelPercent += 0.3f;
    }
    void Update()
    {
        wl.WaterLevelPercent += 0.005f * Time.deltaTime;
    }
}

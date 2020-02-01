using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelControl : MonoBehaviour
{
    private bool isInsideWater = false;
    private WaterLevel wl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInsideWater = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInsideWater = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        wl = GetComponent<WaterLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideWater && Input.GetButtonDown("Fire1"))
        {
            wl.waterLevelPercent -= 0.2f;
            if (wl.waterLevelPercent < 0) wl.waterLevelPercent = 0;
        }
    }
}

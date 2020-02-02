using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float waterLevelPercent = 0;
    public float maxWaterHeight = 2;
    private float lerpWaterLevelPercent = 0;
    private SpriteRenderer sprite0;
    private SpriteRenderer sprite1;
    private Vector3 startPos;

    public float WaterLevelPercent { get => waterLevelPercent; set => waterLevelPercent = Mathf.Clamp(value,0,1); }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        sprite0 = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sprite1 = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite0.enabled = lerpWaterLevelPercent >= 0.01;
        sprite1.enabled = lerpWaterLevelPercent >= 0.01;
        lerpWaterLevelPercent = Mathf.Lerp(lerpWaterLevelPercent, WaterLevelPercent, Time.deltaTime * 2);
        transform.position = startPos + new Vector3(0, lerpWaterLevelPercent * maxWaterHeight, 0);
    }
}

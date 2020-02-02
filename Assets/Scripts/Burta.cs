using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burta : MonoBehaviour
{
    public static Burta _instance;
    public bool isIn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
    }
    public void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

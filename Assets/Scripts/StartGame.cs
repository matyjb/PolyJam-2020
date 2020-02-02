using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private bool t = true;
    public AudioClip intro;
    public AudioClip loop;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().PlayDelayed(intro.length * intro.frequency);
    }

    IEnumerator PlayLoop()
    {

        t = false;
        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().PlayOneShot(intro);
        yield return new WaitForSeconds(intro.length);
        //GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && t)
        if (Input.anyKeyDown && Time.timeScale == 0 && !GameManager.instance.IsShipDead )
        {
            GetComponent<Animator>().SetTrigger("Start");
        StartCoroutine(PlayLoop());
            Time.timeScale = 1;
            GameManager.instance.StartTime();
        }
    }
}

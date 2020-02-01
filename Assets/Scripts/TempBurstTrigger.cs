using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBurstTrigger : MonoBehaviour
{
    ParticleSystem particles;
    Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!particles.isPlaying)
        {
            particles.Play();
            anim.Play("Canon");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

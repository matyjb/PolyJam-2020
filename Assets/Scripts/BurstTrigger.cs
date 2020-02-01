using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTrigger : MonoBehaviour
{
    ParticleSystem particles;
    Animator anim;
    public void FireCanon()
    {
        if (!particles.isPlaying)
        {
            particles.Play();
            anim.SetTrigger("Burst");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

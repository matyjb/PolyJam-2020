using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTrigger : MonoBehaviour
{
    ParticleSystem particles;
    ParticleSystem cannonballPS;
    Animator anim;
    AudioSource audio;

    public void FireCanon()
    {
        if (!particles.isPlaying)
        {
            StartCoroutine( ShootCannon() );
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        particles = GetComponent<ParticleSystem>();
        cannonballPS = GetComponentInChildren<ParticleSystem>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShootCannon()
    {
        audio.Play();
        yield return new WaitForSeconds( .4f );

        particles.Play();
        cannonballPS.Play();
        anim.SetTrigger("Burst");
    }
}

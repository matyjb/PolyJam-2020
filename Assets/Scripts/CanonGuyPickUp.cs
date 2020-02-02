﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonGuyPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canon;
	Animator animator;


	public Vector2 timeForNewKula;

	// Internal
	bool idleing = true;
	float timeLastShoot;
	float nextShotTime = 5;

	private void Awake() {
		animator = GetComponent<Animator>();
		RandomiseNextTime();
	}

	private void Update() {
		if (idleing) {
			if (Time.timeSinceLevelLoad - timeLastShoot >= nextShotTime) {
				StartWaitingForBall();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CanonBall"))
        {
            Destroy(collision.gameObject);
			if (!idleing) {
				StartCoroutine(ShootAnimation());
			}
        }
    }

	IEnumerator ShootAnimation() {
		animator.SetTrigger("GetKula");
		yield return new WaitForSeconds(1f);
		canon.GetComponentInChildren<BurstTrigger>().FireCanon();
		RandomiseNextTime();
		timeLastShoot = Time.timeSinceLevelLoad;
		idleing = true;
	}

	void RandomiseNextTime() {
		nextShotTime = Random.Range(timeForNewKula.x, timeForNewKula.y);
	}

	void StartWaitingForBall() {
		idleing = false;
		animator.SetTrigger("NeedKula");
	}
}

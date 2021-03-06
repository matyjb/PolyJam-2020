﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
	public Vector3 targetPosition;
	public bool onPosition = false;

	public void Setup(Vector3 target) {
		targetPosition = target + (target.x < 0 ? Vector3.right : Vector3.left);

		Rotate(target.x >= 0);
		

	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 3) {
			transform.position += Vector3.down * 0.01f * 80 * Time.deltaTime;
		} else if (!onPosition) {
			transform.position += (targetPosition - transform.position).normalized * 3 * Time.deltaTime;
			if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
				onPosition = true;
				transform.position = targetPosition;
			}
		}
    }

	public void StartAnimate() {
		GetComponent<Animator>().SetTrigger("Attack");
	}

	void Rotate(bool right) {
		Vector3 rotation = transform.GetChild(0).rotation.eulerAngles;
		if (right)
			rotation.y = 180;
		else
			rotation.y = 0;
		transform.GetChild(0).rotation = Quaternion.Euler(rotation);
	}
}

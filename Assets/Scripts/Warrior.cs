﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
	public Vector3 targetPosition;
	bool onPosition = false;

	public void Setup(Vector3 target) {
		targetPosition = target + Vector3.down / 2;
	}

	// Update is called once per frame
	void Update() {
		transform.position += (targetPosition - transform.position).normalized * 3 * Time.deltaTime;
		if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
			onPosition = true;
			transform.position = targetPosition;
		}
	}
}

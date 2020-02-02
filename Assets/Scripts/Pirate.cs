using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
	public Vector3 targetPosition;
	bool onPosition = false;

	public void Setup(Vector3 target, bool pirateIsRight) {
		targetPosition = target + (pirateIsRight ? Vector3.right : Vector3.left);
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
}

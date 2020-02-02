using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
	public Vector3 targetPosition;
	bool onPosition;
	Pirate pirate;


	public void Setup(Vector3 target, Pirate pirate) {
		targetPosition = target + (target.x >= 0 ? Vector3.right : Vector3.left);
		this.pirate = pirate;

		Rotate(target.x < 0);
	}

	// Update is called once per frame
	void Update() {
		if (!onPosition) {
			transform.position += (targetPosition - transform.position).normalized * 3 * Time.deltaTime;
			if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
				transform.position = targetPosition;
				if (pirate.onPosition) {
					onPosition = true;
					GetComponent<Animator>().SetTrigger("Attack");
					pirate.StartAnimate();
				}
			}
		}
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

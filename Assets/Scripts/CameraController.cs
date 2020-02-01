using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform focusTransform;

	public Vector3 offset;
	public Vector2 boundingBoxSize;
	public Vector2 maxCameraMove;

	Vector3 camPos;

	// Update is called once per frame
	void Update() {
		camPos = transform.position;
		Vector3 focusPos = focusTransform.position;
		Vector3 difference = focusPos - camPos;



		// If the focus point is outside the bounding box
		if (difference.x > boundingBoxSize.x) {
			transform.position += new Vector3(difference.x - boundingBoxSize.x, 0, 0);
		} else if (difference.x < -boundingBoxSize.x) {
			transform.position += new Vector3(difference.x + boundingBoxSize.x, 0, 0);
		}
		if (difference.y > boundingBoxSize.y) {
			transform.position += new Vector3(0, difference.y - boundingBoxSize.y, 0);
		} else if (difference.y < -boundingBoxSize.y) {
			transform.position += new Vector3(0, difference.y + boundingBoxSize.y, 0);
		}
		CamMaxMove();
	}

	void CamMaxMove() {
		camPos = transform.position;
		if (camPos.x > maxCameraMove.x)
			camPos.x = maxCameraMove.x;
		else if (camPos.x < -maxCameraMove.x)
			camPos.x = -maxCameraMove.x;

		if (camPos.y > maxCameraMove.y)
			camPos.y = maxCameraMove.y;
		else if (camPos.y < -maxCameraMove.y)
			camPos.y = -maxCameraMove.y;

		transform.position = camPos;
	}

}

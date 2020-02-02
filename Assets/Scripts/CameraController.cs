using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform focusTransform;

	public Vector3 offset;
	public Vector2 boundingBoxSize;
	public Vector2 maxCameraMove;

	Vector3 camPos;

	// Camera shake
	public float maxShakeDuration;
	float shakeDuration = 0f;
	public float defaultShakeMagnitude;
	float shakeMagnitude;
	float dampingSpeed = 1.0f;

	private List<Rect> allowedAreas;

	private void Start()
	{
		allowedAreas = new List<Rect>
		{
			new Rect(new Vector2(-maxCameraMove.x,maxCameraMove.y),maxCameraMove*2),
			new Rect(new Vector2(-maxCameraMove.x,maxCameraMove.y-25),maxCameraMove*2),
		};
	}
	// Update is called once per frame
	void Update()
	{
		camPos = transform.position;
		Vector3 focusPos = focusTransform.position;
		Vector3 difference = focusPos - camPos;


		// If the focus point is outside the bounding box
		if( difference.x > boundingBoxSize.x )
		{
			transform.position += new Vector3( difference.x - boundingBoxSize.x, 0, 0 );
		}
		else if( difference.x < -boundingBoxSize.x )
		{
			transform.position += new Vector3( difference.x + boundingBoxSize.x, 0, 0 );
		}
		if( difference.y > boundingBoxSize.y )
		{
			transform.position += new Vector3( 0, difference.y - boundingBoxSize.y, 0 );
		}
		else if( difference.y < -boundingBoxSize.y )
		{
			transform.position += new Vector3( 0, difference.y + boundingBoxSize.y, 0 );
		}
		CamMaxMove();

		HandleCameraShake();
	}

	void CamMaxMove()
	{
		Rect r = allowedAreas[0];
		for (int i = 1; i < allowedAreas.Count; i++)
		{
			float rr = Vector2.Distance(r.center, transform.position);
			float aa = Vector2.Distance(allowedAreas[i].center, transform.position);
			if (aa < rr) r = allowedAreas[i];
		}
		camPos = transform.position;

		if (camPos.x < r.xMin) camPos.x = r.xMin;
		if (camPos.x > r.xMax) camPos.x = r.xMax;

		if (camPos.y < r.yMin) camPos.y = r.yMin;
		if (camPos.y > r.yMax) camPos.y = r.yMax;
		//if( camPos.x > maxCameraMove.x )
		//	camPos.x = maxCameraMove.x;
		//else if( camPos.x < -maxCameraMove.x )
		//	camPos.x = -maxCameraMove.x;

		//if( camPos.y > maxCameraMove.y )
		//	camPos.y = maxCameraMove.y;
		//else if( camPos.y < -maxCameraMove.y )
		//	camPos.y = -maxCameraMove.y;

		transform.position = camPos;
	}

	void HandleCameraShake()
	{
		if( shakeDuration > 0 )
		{
			transform.position += (Vector3)Random.insideUnitCircle * shakeMagnitude; 
			shakeDuration -= Time.deltaTime * dampingSpeed;
		}
		else
		{
			shakeMagnitude = defaultShakeMagnitude;
		}
	}

	public void TriggerShake()
	{
		if( shakeDuration > 0 )
			shakeMagnitude += defaultShakeMagnitude;
		shakeDuration = maxShakeDuration;
	}
}

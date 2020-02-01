using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform focusTransform;

	public Vector3 offset;
	public Vector2 boundingBoxSize;


	// Update is called once per frame
	void Update()
	{
		Vector3 camPos = transform.position;
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
	}

}

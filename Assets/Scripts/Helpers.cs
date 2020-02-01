using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
	public static Vector2 StretchXVelocity(Vector2 velocity) {
		return velocity *= new Vector2(2, 1);
	}
}

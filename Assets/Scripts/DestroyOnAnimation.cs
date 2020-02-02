using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimation : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<AudioSource>().Play();
	}
	public void DestroyAnim() {
		Destroy(gameObject);
	}
}

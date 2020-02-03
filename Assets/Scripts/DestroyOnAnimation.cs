using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimation : MonoBehaviour
{
	private void Awake()
	{
		AudioSource audioSource = GetComponent<AudioSource>();
		if( audioSource != null ) audioSource.Play();
	}
	public void DestroyAnim() {
		Destroy(gameObject);
	}
}

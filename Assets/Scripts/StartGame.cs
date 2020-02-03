using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	private bool introScreen = true;
	public AudioClip introMusic;
	AudioSource audioSource;
	Animator animator;

	// Start is called before the first frame update
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if( introScreen && Input.anyKeyDown )
		{
			animator.SetTrigger( "Start" );
			StartCoroutine( PlayLoop() );
			Time.timeScale = 1;
			GameManager.instance.StartTime();
		}
	}

	// Play loop music after intro music ends
	IEnumerator PlayLoop()
	{
		introScreen = false;
		yield return new WaitForSeconds( introMusic.length );
		audioSource.Play();
	}
}

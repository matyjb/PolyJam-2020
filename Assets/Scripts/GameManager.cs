using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[Header( "Player" )]
	public GameObject player;


	// Health
	float shipHealth;
	public bool IsShipDead
	{
		get
		{
			return shipHealth <= 0;
		}
	}

	// Points
	public int cannonsShot;
	public int holesHixed;
	public int bucketsEmptied;
	public int points;

	// Time
	float gameplayStartTime;
	public float gameTime;

	// UI
	public Slider shipHealthUI;

	// Gameover UI
	public GameObject gameOverUI;
	public Text cannonPoints;
	public Text holePoints;
	public Text bucketPoints;
	public Text totalPoints;


	private void Awake()
	{
		Time.timeScale = 1;
		instance = this;
	}

	void Start()
	{
		gameplayStartTime = Time.realtimeSinceStartup;
		gameTime = 0;
		points = 0;

		shipHealth = 1.0f;

		gameOverUI.SetActive( false );
	}

	void Update()
	{
		shipHealthUI.value = shipHealth;

		if( IsShipDead )
		{
			Time.timeScale = 0;
			if( !gameOverUI.activeSelf )
			{
				SetGameOverUI();
			}
		}
		else
		{
			gameTime = Time.realtimeSinceStartup - gameplayStartTime;
		}

		// Temp suicide button
		if( Input.GetKeyDown( KeyCode.P ) )
			shipHealth = 0;
	}

	public void DamageShip( float damage )
	{
		shipHealth -= damage;
	}

	void SetGameOverUI()
	{
		shipHealthUI.gameObject.SetActive( false );
		gameOverUI.SetActive( true );
		cannonPoints.text = $"<b>{cannonsShot}</b>";
		holePoints.text = $"<b>{holesHixed}</b>";
		bucketPoints.text = $"<b>{bucketsEmptied}</b>";
		totalPoints.text = $"<b>{cannonsShot*5 + holesHixed*2 + bucketsEmptied*3 }</b>";
	}
}

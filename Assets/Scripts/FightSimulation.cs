﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSimulation : MonoBehaviour
{

	[Header( "Prefabs" )]
	public GameObject piratePrefab;
	public GameObject warriorPrefab;
	public GameObject exclMarkPrefab;

	[Header( "SpawnGo" )]
	public GameObject pirateWarriorGo;
	public GameObject leftMarkGo;
	public GameObject rightMarkGo;

	List<Vector3> fightPair = new List<Vector3>();

	List<GameObject> pirates = new List<GameObject>();
	List<GameObject> warriors = new List<GameObject>();

	public void SpawnPair()
	{
		bool isPirateRight = true;
		if( Random.Range( 0, 2 ) == 0 )
			isPirateRight = false;

		Vector3 targetPosition;
		int safeMode = 0;
		do
		{
			targetPosition = new Vector2( Random.Range( -5f, 5f ), Random.Range( -2f, 2f ) );
			safeMode++;
		} while( !CheckForClose( targetPosition ) && safeMode < 20  );
		fightPair.Add( targetPosition );

		// Pirate
		GameObject tempGo = Instantiate( piratePrefab, new Vector3( 0, 5.5f, 0 ), transform.rotation, pirateWarriorGo.transform );
		pirates.Add( tempGo );
		tempGo.GetComponent<Pirate>().Setup( targetPosition, isPirateRight );

		// Warrior
		StartCoroutine( SpawnWarriorAfterTime( targetPosition, isPirateRight ) );

	}

	IEnumerator SpawnWarriorAfterTime( Vector3 targetPosition, bool isPirateRight )
	{
		yield return new WaitForSeconds( Random.Range( 1f, 2.5f ) );
		SpawnExclMark( targetPosition );
		yield return new WaitForSeconds( 1.05f );
		int multiplayer = -1;
		if( targetPosition.x >= 0 )
			multiplayer *= -1;
		GameObject tempGo = Instantiate( warriorPrefab, new Vector3( 8 * multiplayer, 0, 0 ), transform.rotation, pirateWarriorGo.transform );
		warriors.Add( tempGo );
		tempGo.GetComponent<Warrior>().Setup( targetPosition, isPirateRight );
	}

	bool CheckForClose( Vector3 position )
	{
		for( int i = 0; i < fightPair.Count; i++ )
		{
			if( Vector3.Distance( position, fightPair[ i ] ) < 0.5f )
				return false;
			if( Mathf.Abs( position.x - fightPair[ i ].x ) < 1.5f )
				return false;
		}
		return true;
	}

	void SpawnExclMark( Vector3 pos )
	{
		GameObject tempGo = Instantiate( exclMarkPrefab );
		if( pos.x >= 0 )
			tempGo.transform.SetParent( rightMarkGo.transform );
		else
			tempGo.transform.SetParent( leftMarkGo.transform );
		tempGo.transform.localScale = tempGo.transform.lossyScale;
		tempGo.transform.localPosition = Vector2.zero;
	}
}

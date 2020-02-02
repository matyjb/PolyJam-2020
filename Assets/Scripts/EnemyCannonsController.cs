using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonsController : MonoBehaviour
{
    Vector2 holeSpawnArea = new Vector2( 7f, 2.5f );
    public GameObject holePrefab;
    GameManager gm;

    public int phase;
    float minShootingDelay;
    float maxShootingDelay;
    float currentShotTime;
    int minShots;
    int maxShots;


    // Start is called before the first frame update
    void Start()
    {
        phase = 0;
        gm = GameManager.instance;
        currentShotTime = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        PhaseSwithing();

        if( currentShotTime <= 0 )
        {
            currentShotTime = Random.Range( minShootingDelay, maxShootingDelay );
            ShootCannons( Random.Range( minShots, maxShots ) );
        }
        currentShotTime -= Time.deltaTime;

        if( Input.GetKeyDown( KeyCode.K ) )
            ShootCannons( 2 );
    }

    void PhaseSwithing()
    {
        if( gm.gameTime < 5 )
        {
            phase = 0;
            minShootingDelay = 10f;
            maxShootingDelay = 10f;
            minShots = 0;
            maxShots = 0;
        }
        if( gm.gameTime < 20 )
        {
            phase = 1;
            minShootingDelay = 5f;
            maxShootingDelay = 10f;
            minShots = 1;
            maxShots = 1;
        }
        else if( gm.gameTime < 40 )
        {
            phase = 2;
            minShootingDelay = 4f;
            maxShootingDelay = 10f;
            minShots = 1;
            maxShots = 2;
        }
        else if( gm.gameTime < 100 )
        {
            phase = 3;
            minShootingDelay = 4f;
            maxShootingDelay = 8f;
            minShots = 1;
            maxShots = 3;
        }
        else if( gm.gameTime < 200 )
        {
            phase = 4;
            minShootingDelay = 3f;
            maxShootingDelay = 7f;
            minShots = 3;
            maxShots = 5;
        }
    }

    void ShootCannons( int nrOfShots )
    {
        for( int i = 0; i < nrOfShots; i++ )
        {
            SpawnRandomHole();
        }
    }

    void SpawnRandomHole()
    {
        Vector2 randomPos;
        Vector2 colliderOffset = holePrefab.GetComponent<CircleCollider2D>().offset;
        float circleRadius = holePrefab.GetComponent<CircleCollider2D>().radius * 1.2f;

        Collider2D collision = null;
        bool hole = false;

        for( int i = 0; hole == false && i < 50; ++i )
        {
            randomPos = new Vector2(
                Random.Range( -holeSpawnArea.x, holeSpawnArea.x ),
                Random.Range( -holeSpawnArea.y, holeSpawnArea.y ) );
            collision = Physics2D.OverlapCircle( randomPos + colliderOffset, circleRadius );

            if( collision == null )
            {
                Instantiate( holePrefab, randomPos, holePrefab.transform.rotation );
                hole = true;
            }
        }
        if( hole == false )
        {
            Debug.Log( "Couldn't spawn hole" );
        }
    }
}

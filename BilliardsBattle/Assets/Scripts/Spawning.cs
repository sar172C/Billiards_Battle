using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    Vector3[] Spawnpoints = new Vector3[20];
    [SerializeField] Transform wallPrefab;
   
    [SerializeField] Transform heart;

    // Start is called before the first frame update
    void Start()
    {
        Spawnpoints[0] = new Vector3(-6, 2, 0);
        Spawnpoints[1] = new Vector3(-6, -1, 0);
        Spawnpoints[3] = new Vector3(-6, -4, 0);
        Spawnpoints[4] = new Vector3(-1, 2, 0);
        Spawnpoints[5] = new Vector3(-1, -1, 0);
        Spawnpoints[6] = new Vector3(-1, -4, 0);
        Spawnpoints[7] = new Vector3(3, 2, 0);
        Spawnpoints[8] = new Vector3(3, -1, 0);
        Spawnpoints[9] = new Vector3(3, -4, 0);
        Spawnpoints[10] = new Vector3(6.2f, 2, 0);
        Spawnpoints[2] = new Vector3(6.2f, -1, 0);
        Spawnpoints[11] = new Vector3(6.2f, -4, 0);

         spawnHeart(heart);

        spawnWalls(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBalls(GameObject PlayerBall, GameObject EnemyBall)
    {
      
        var ballSpawned = false;
        var enemySpawned = false;

        while (ballSpawned == false)
        {
            Vector3 tryBallSpawn = new Vector3(Random.Range(-7, 7), Random.Range(-4, 2), 0);
            var ballHitColliders = Physics.OverlapSphere(tryBallSpawn, 3.5f);
            if (ballHitColliders.Length <= 0)
            {
                PlayerBall.transform.position = tryBallSpawn;
                PlayerBall.GetComponent<PlayerShooter>().enabled = true;
                ballSpawned = true;
            }
        }

        while (enemySpawned == false)
        {
            Vector3 tryEnemySpawn = new Vector3(Random.Range(-7, 7), Random.Range(-4, 2), 0);
            var enemyHitColliders = Physics.OverlapSphere(tryEnemySpawn, 3.5f);
            if (enemyHitColliders.Length <= 0)
            {
                EnemyBall.transform.position = tryEnemySpawn;
                enemySpawned = true;
                EnemyBall.GetComponent<EnemyMove>().enabled = true;
            }
        }

    }

    void spawnWalls(int wallNum)
    {
        for (int i = 1; i <= wallNum; i++)
        {
            var spawned = false;
            while (spawned == false)
            {
                Vector3 trySpawn = new Vector3(Random.Range(-7, 7), Random.Range(-4, 2), 0);
                var hitColliders = Physics.OverlapSphere(trySpawn, 3.5f);
                if (hitColliders.Length <= 0)
                {
                    Instantiate(wallPrefab, trySpawn, Quaternion.Euler(0, 0, Random.Range(0, 180)));
                    spawned = true;
                }
            }
        }
    }


    void spawnHeart(Transform heart)
    {
        var heartSpawned = false;

        while (heartSpawned == false)
        {
            Vector3 tryHeartSpawn = new Vector3(Random.Range(-7, 7), Random.Range(-4, 2), 0);
            var heartHitColliders = Physics.OverlapSphere(tryHeartSpawn, 2.5f);
            if (heartHitColliders.Length <= 0)
            {
                heart.transform.position = tryHeartSpawn;
                heartSpawned = true;
            }
        }
    }

}

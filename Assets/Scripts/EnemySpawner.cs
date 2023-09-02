using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private GameObject[] enemyArr;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private Transform minSpawn, maxSpawn;

    private float spawnCounter;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeToSpawn;

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;

            //Instantiate(enemyToSpawn, transform.position, transform.rotation);
            for (int i = 0; i < enemyArr.Length; i++)
            {
                Instantiate(enemyArr[i], SelectSpawnPoint(), transform.rotation);
            }
        }
        if(target)
        {
            transform.position = target.position;
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if(Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }else{
                spawnPoint.x = minSpawn.position.x;
            }
        } else{
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

                if(Random.Range(0f, 1f) > .5f)
                {
                    spawnPoint.y = maxSpawn.position.y;
                }else{
                    spawnPoint.y = minSpawn.position.y;
                }
        }

        return spawnPoint;
    }
}

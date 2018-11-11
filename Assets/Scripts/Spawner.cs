using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float timeToLive = 10f;

    private Vector3 objectPoolPosition = new Vector3(60, 60, 60);
    private float timeSinceLastSpawn;
    private GameObject[] obstacles;

	void Start () {
        obstacles = new GameObject[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }

    }

    void Update ()
    {
        WaitToSpawn();
    }

    private void WaitToSpawn()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeToLive)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                obstacles[i].transform.position = spawnPoints[i].transform.position;
                timeSinceLastSpawn = 0;
            }
        }
    }
}

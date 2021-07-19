using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesToSpawn;
    [SerializeField] private Transform spawnPoint;
    private float _spawnTime;

    private void Start()
    {
        _spawnTime = 1.5f;
        StartCoroutine(CreateNewObstacle());
    }

    private IEnumerator CreateNewObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            Instantiate(obstaclesToSpawn[Random.Range(0, obstaclesToSpawn.Length)], spawnPoint.position, Quaternion.identity); 
        }
    }


}

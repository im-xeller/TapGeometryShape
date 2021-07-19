using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    [SerializeField] private GameObject backgroundEnvironment;
    [SerializeField] private Transform[] spawnPoints;

    private void FixedUpdate()
    {
        Instantiate(backgroundEnvironment, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
}

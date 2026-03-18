using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20, 0, 2);
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle ()
    {
       Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); 
    }
}

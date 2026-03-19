using UnityEngine;

public class SpawnManeger : MonoBehaviour
{
//Variaveis
    //Obstaculos Spawn:
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20, 0, 0);

    //Inetrvalo de Spawn
    private float startDelay = 2;
    private float repeatRate = 2;
    //Script do player:
    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle ()
    {
        if(playerControllerScript.gameOver == false)
        {
           Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);  
        }
       
    }
}

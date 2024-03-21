using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(22, 0.5f, 0);
    private int rand;
    private float iSpawnDelay = 1;
    private float spawnDelay = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", iSpawnDelay, spawnDelay);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnObstacle(){
        if(!playerController.gameOver){
            rand = Random.Range(0, obstaclePrefabs.Length-1);
            Instantiate(obstaclePrefabs[rand], spawnPos, obstaclePrefabs[rand].transform.rotation);
        }
    }
}

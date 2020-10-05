using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector3 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) 
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-11f, 91f);
            whereToSpawn = new Vector3(randX, transform.position.y,transform.position.z);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}

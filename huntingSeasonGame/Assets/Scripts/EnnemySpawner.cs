using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public GameObject smallEnnemies;
    public GameObject bigEnnemies;
    public GameObject boss;
  
    private float spawnSmallInterval = 1f;
    private float spawnBigInterval = 3f;
    private float spawnBossInterval = 10f;

   // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
        StartCoroutine(spawnEnnemies(spawnBigInterval, bigEnnemies));
        StartCoroutine(spawnEnnemies(spawnBigInterval, boss));
    }

    private IEnumerator spawnEnnemies(float interval, GameObject ennemy)
    {
        yield return new WaitForSeconds(interval);
        Vector2 randomPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-6f, 6f));
        float distance = Vector2.Distance(transform.position, randomPos);
        
        if(distance >= 6f){
            Instantiate(ennemy, randomPos, Quaternion.identity);
        }
        
        StartCoroutine(spawnEnnemies(interval, ennemy));
             
    }
}

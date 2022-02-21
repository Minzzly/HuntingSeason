using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public GameObject smallEnnemies;
    public GameObject bigEnnemies;
    public GameObject boss;
    public GameObject master;
  
    private float spawnSmallInterval = 1f;
    private float spawnBigInterval = 3f;
    private float spawnBossInterval = 3f;
    private float spawnMasterInterval = 40f;

   // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
        StartCoroutine(spawnEnnemies(spawnBigInterval, bigEnnemies));
        StartCoroutine(spawnEnnemies(spawnBossInterval, boss));
        StartCoroutine(spawnMasters(spawnMasterInterval, master));
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

    private IEnumerator spawnMasters(float interval, GameObject ennemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject spawnPoint = GameObject.Find("spawnPoint" + Random.Range(1, 4).ToString());

        Vector2 randomPos = spawnPoint.transform.position;

        Instantiate(ennemy, randomPos, Quaternion.identity);
    
        
        StartCoroutine(spawnMasters(interval, ennemy));
             
    }
}

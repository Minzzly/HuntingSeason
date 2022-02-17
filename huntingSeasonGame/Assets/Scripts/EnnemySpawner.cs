using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public GameObject smallEnnemies;
  
    private float spawnSmallInterval = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
    }

    private IEnumerator spawnEnnemies(float interval, GameObject ennemy)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(ennemy, new Vector2(Random.Range(-15f, -5f), Random.Range(-6f, 6f)), Quaternion.identity);
        Instantiate(ennemy, new Vector2(Random.Range(5f, 15f), Random.Range(-6f, 6f)), Quaternion.identity);
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
             
    }
}

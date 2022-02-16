using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{

    public GameObject smallEnnemies;
  
    private float spawnSmallInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
    }

    private IEnumerator spawnEnnemies(float interval, GameObject ennemy)
    {
        Debug.Log("yeet");
        yield return new WaitForSeconds(interval);
        Instantiate(ennemy, new Vector2(Random.Range(-10f, 10f), Random.Range(-6f, 6f)), Quaternion.identity);
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
             
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{

    private float speed = 2f;
    public Transform target;
    public float lifePoints = 1;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(lifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}

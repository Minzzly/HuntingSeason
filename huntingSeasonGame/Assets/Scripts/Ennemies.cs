using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemies : MonoBehaviour
{

    public float speed = 2f;
    public Transform target;
    public float lifePoints;
    private float maxLifePoints;

    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    private float rotationOffset = 90;

    public int score = 10;

    public Heatlbar heatlbar;



    // Start is called before the first frame update
    void Start()
    {
        maxLifePoints = lifePoints;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        heatlbar.SetHealth(lifePoints, maxLifePoints);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        if(lifePoints <= 0)
        {
            Destroy(gameObject);
        }

        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        
    }

    public void TakeDamage(){
        lifePoints --;
        heatlbar.SetHealth(lifePoints, maxLifePoints);
    }


}
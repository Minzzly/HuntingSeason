using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public float speed;
    private float rotationOffset = 90;
    private Animator animHero;
    private int score;
    public Text scoreText;
    public Data scoreEntry;

    private LayerMask mask;

    
    

    // Start is called before the first frame update
    void Start()
    {
        animHero = GetComponent<Animator>();
        mask = LayerMask.GetMask("Enemy");
        scoreEntry.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            animHero.SetTrigger("shoot");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 50f, mask);

            if(hit){
                GameObject monster = hit.transform.gameObject;
                monster.GetComponent<Ennemies>().TakeDamage();

                int scoreEnnemies = hit.transform.gameObject.GetComponent<Ennemies>().score;
                score += scoreEnnemies;
                scoreText.text = "Score : " + score;
                scoreEntry.score = score;
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene("End");
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public float speed;
    private float rotationOffset = 90;
    private Animator animHero;
    private int score = 0;
    public Text scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        animHero = GetComponent<Animator>();
        Debug.Log(scoreText.text);
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 50f);

            Destroy(hit.transform.gameObject);
            score = hit.transform.gameObject.GetComponent<Ennemies>().score;
           
            int scoreEnnemies = hit.transform.gameObject.GetComponent<Ennemies>().score;
            scoreText.text = "Score :" + (score + scoreEnnemies);
            
        }
            
    

    }
}

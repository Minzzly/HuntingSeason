using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private string scene; 
    public Data scoreEntry;

    [SerializeField]private int squelettonValue = 0;
    private GameObject squeletton;

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;

        if(scene == "Start"){
            scoreEntry.score = 0;
        }
        else if(scene == "End" || scene == "Win")
        {
            GameObject finalScore = GameObject.Find("finalScore");
            finalScore.GetComponent<Text>().text = "Score : " + scoreEntry.score + " points";
        }


    }


    public void AddSqueleton(){
        squelettonValue ++;
        squeletton = GameObject.Find("squeletton" + squelettonValue.ToString());
        squeletton.GetComponent<Image>().enabled = true;

        if(squelettonValue == 8){
            WinGame();
        }
    }

    public void LoadLevel(){
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame(){
        Application.Quit();
    }

    private void WinGame(){
        SceneManager.LoadScene("Win");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private string scene; 
    public Data scoreEntry;

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;

        if(scene == "Start"){
            scoreEntry.score = 0;
        }
        else if(scene == "End")
        {
            GameObject finalScore = GameObject.Find("finalScore");
            finalScore.GetComponent<Text>().text = "Score : " + scoreEntry.score + " points";
        }
    }

    public void LoadLevel(){
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame(){
        Application.Quit();
    }
}

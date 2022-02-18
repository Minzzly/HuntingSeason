using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void LoadLevel(){
        SceneManager.LoadScene("Scene1");
    }

    public void RestartGame(){
        SceneManager.LoadScene("Start");
    }

}

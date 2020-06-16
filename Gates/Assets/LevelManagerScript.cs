using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManagerScript : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}

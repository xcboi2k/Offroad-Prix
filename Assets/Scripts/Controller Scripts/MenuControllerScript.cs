using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour
{
    private const string level = "Level";

    void Start() {
        PlayerPrefs.SetInt(level, 1);
    }
    public void PlayGame(){
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseContinueControllerScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    private const string level = "Level";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameplayScene");
    }

    public void NextLevel(){
        int getLevel = PlayerPrefs.GetInt(level);

        if(getLevel == 1){
            PlayerPrefs.SetInt(level, 2);
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameplayScene");
        }

        else if(getLevel == 2){
            PlayerPrefs.SetInt(level, 3);
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameplayScene");
        }
    }
}
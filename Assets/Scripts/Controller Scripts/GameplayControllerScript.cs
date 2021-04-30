using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayControllerScript : MonoBehaviour
{
    public GameObject level1, level2, level3;
    public GameObject nextLevelButton;
    public GameObject signLevel1, signLevel2, signLevel3;

    public Text coinsText;
    
    public int coins = 0;
    int finalcount_coins;

    private const string level = "Level";

    void Start() {
        int getLevel = PlayerPrefs.GetInt(level);

        if(getLevel == 1){
            signLevel1.SetActive(true);
            level1.SetActive(true);
        }

        else if(getLevel == 2){
            signLevel2.SetActive(true);
            level2.SetActive(true);
        }

        else if(getLevel == 3){
            signLevel3.SetActive(true);
            level3.SetActive(true);
            nextLevelButton.SetActive(false);
        }

    }
    void Update()
    {
        finalcount_coins += coins;
        coinsText.text = "" + coins;
    }
}

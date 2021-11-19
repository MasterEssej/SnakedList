using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;
    public Text foodAmount;
    private void Start()
    {
        highScore.text = "Highscore\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
        foodAmount.text = PlayerPrefs.GetInt("FoodSpawns", 1).ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScore.text = "Highscore\n" + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void FoodAmount()
    {
        PlayerPrefs.SetInt("FoodSpawns", PlayerPrefs.GetInt("FoodSpawns") + 1);
        if(PlayerPrefs.GetInt("FoodSpawns") > 5)
        {
            PlayerPrefs.SetInt("FoodSpawns", 1);
        }
        foodAmount.text = PlayerPrefs.GetInt("FoodSpawns", 1).ToString();
    }

}

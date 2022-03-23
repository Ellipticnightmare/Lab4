using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;
    public GameObject instructions;
    public void HitPlay()
    {
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("curScore", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void HitQuit() => Application.Quit();
    private void Update()
    {
        int scoreVal = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = (scoreVal.ToString("000000"));
    }
    public void OpenInstructions()
    {
        instructions.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructions.SetActive(false);
    }
}

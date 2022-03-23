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
        PlayerPrefs.SetInt("BasicKill", 0);
        PlayerPrefs.SetInt("FastKill", 0);
        PlayerPrefs.SetInt("liveN", 1);
        SceneManager.LoadScene("SampleScene");
    }
    public void HitQuit() => Application.Quit();

    private void Update()
    {
        int scoreVal = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = (scoreVal.ToString("000000"));
    }
    public void ToggleInstructions() => instructions.SetActive(!instructions.activeInHierarchy);
}

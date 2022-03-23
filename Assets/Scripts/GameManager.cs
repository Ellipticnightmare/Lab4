using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public GameObject resultsUI;
    int lives;
    public enemyKillData[] enemyKillDataStorage;
    [Header("DON'T ASSIGN")]
    public int basicEnemyKillCount, fastEnemyKillCount;
    private void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
        score = PlayerPrefs.GetInt("Score");
    }
    private void Update()
    {
        //disabled for now cus it was just giving 1000000 array exceptions
        //basicEnemyKillCount = enemyKillDataStorage[0].enemyKillCount;
        //fastEnemyKillCount = enemyKillDataStorage[1].enemyKillCount;
    }
    public static void TakeHit()
    {
        if (!PlayerController.isShield)
            FindObjectOfType<GameManager>().KillPlayer();
        else
            PlayerController.isShield = false;
    }
    public void KillPlayer()
    {
        lives--;
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Score", score);
        if (lives >= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            GameOver();
    }
    public void GameOver()
    {
        Debug.Log("game over!");
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
        //Run Game Over logic here, for results screen and such, etc etc
        resultsUI.SetActive(true);

    }
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene");
        resultsUI.SetActive(false);
    }
    public void LoadMainMenu()
    {
        resultsUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public static void HitEnemy(int score, string enemyName)
    {
        score += score;
        FindObjectOfType<GameManager>().UpdateKillData(enemyName);
    }
    public void UpdateKillData(string enemyName)
    {
        if (enemyName == "Basic")
            enemyKillDataStorage[0].enemyKillCount++;
        else
            enemyKillDataStorage[1].enemyKillCount++;
    }
}
[System.Serializable]
public struct enemyKillData
{
    public string enemyName;
    public int enemyKillCount;
}
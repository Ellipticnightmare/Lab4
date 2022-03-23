using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public NavMeshSurface2d Surface2D;
    public int score;
    public GameObject resultsUI;
    int lives;
    public enemyKillData[] enemyKillDataStorage;
    int basicEnemyKillCount, fastEnemyKillCount;
    private void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
        score = PlayerPrefs.GetInt("Score");
        enemyKillDataStorage[0].enemyKillCount = PlayerPrefs.GetInt("BasicKill");
        enemyKillDataStorage[1].enemyKillCount = PlayerPrefs.GetInt("FastKill");
    }
    private void Update()
    {
        basicEnemyKillCount = enemyKillDataStorage[0].enemyKillCount;
        fastEnemyKillCount = enemyKillDataStorage[1].enemyKillCount;
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
        PlayerPrefs.SetInt("BasicKill", basicEnemyKillCount);
        PlayerPrefs.SetInt("FastKill", fastEnemyKillCount);
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
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("BasicKill", 0);
        PlayerPrefs.SetInt("FastKill", 0);
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
        if (enemyName == "greenEnemy")
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
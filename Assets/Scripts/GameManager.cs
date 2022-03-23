﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    int lives;
    public enemyKillData[] enemyKillDataStorage;
    [Header("DON'T ASSIGN")]
    public int basicEnemyKillCount, fastEnemyKillCount;
    public GameObject results;
    private void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
        score = PlayerPrefs.GetInt("Score");
    }
    private void Update()
    {
        basicEnemyKillCount = enemyKillDataStorage[0].enemyKillCount;
        fastEnemyKillCount = enemyKillDataStorage[1].enemyKillCount;
    }
    public static void TakeHit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void HitEnemy(int score)
    {
        lives--;
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Score", score);
        if (lives >= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        else
            GameOver();
    }
    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
        //Run Game Over logic here, for results screen and such, etc etc
        results.SetActive(true);
    }
    public static void HitEnemy(int score, string enemyName)
    {
        score += score;
    }
    public void UpdateKillData(string enemyName)
    {
        if (enemyName == "Basic")
            enemyKillDataStorage[0].enemyKillCount++;
        else
            enemyKillDataStorage[1].enemyKillCount++;
    }
    public void CloseResults()
    {
        results.SetActive(false);
    }
    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        else
            GameOver();
    }
    public static void HitEnemy(int score)
    {
        score += score;
    }
}

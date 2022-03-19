using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public static void TakeHit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void HitEnemy(int score)
    {
        score += score;
    }
}
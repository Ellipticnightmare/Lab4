using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject instructions;
    public GameObject results;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        if (results == null)
        {
            results = FindObjectOfType<GameObject>().name == "ResultsScreen";
        }
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        results = null;
    }

    public void OpenInstructions()
    {
        instructions.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructions.SetActive(false);
    }

    public void OpenResults()
    {
        results.SetActive(true);
    }

    public void CloseResults()
    {
        results.SetActive(false);
    }
}

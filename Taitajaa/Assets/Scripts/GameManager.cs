using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SpawnManager.instance.SpawnWalls();
    }

    public void Restart()
    {
        SpawnManager.instance.DestroyWalls();
        SpawnManager.instance.SpawnWalls();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

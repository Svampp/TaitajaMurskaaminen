using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 playerStartPos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnManager.instance.SpawnWalls();
    }

    public void Restart()
    {
        SpawnManager.instance.DestroyWalls();
        SpawnManager.instance.SpawnWalls();

        player.transform.position = playerStartPos;
        PlayerController.instance.ResetHealth();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

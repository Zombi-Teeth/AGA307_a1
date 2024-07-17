using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    public Difficulty difficulty;
    int scoreMultipler = 1;
    static public int score = 100;

    public GameObject ScoreTextBox;
    public GameObject pauseMenuUI;
    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
        // difficulty = Difficulty.Easy;

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }


    void Setup()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultipler = 1;
                break;
            case Difficulty.Medium:
                scoreMultipler = 2;
                break;
            case Difficulty.Hard:
                scoreMultipler = 3;
                break;
            default:
                scoreMultipler = 1;
                break;

        }

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
    }


    public void Pause()
    {
        
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);

    }

}
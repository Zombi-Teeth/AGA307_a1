using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    public Difficulty difficulty;
    int scoreMultipler = 1;


    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
        // difficulty = Difficulty.Easy;
        GameEvents.;EnemyHit += EnemyHit;
        StartCoroutine(timer());

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
}

public class ScoreManager : MonoBehaviour
{

    static public int score = 100;

    public GameObject ScoreTextBox;


    // Update is called once per frame
    void Update()
    {
        ScoreTextBox.GetComponent<Text>().text = Score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd * scoreMultiplyer;
    }

    void EnemyHit(Enemy e)
    {
        AddScore(10);
    }
}

public void ResumeGame()
{ 
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

void PauseGame()
{
    pauseMenuUI.SetActive(true);
    Timeout.timeScale = 0f;
    isPaused = true;

    Cursor.lockstate + CursorLockMode.None;
    Cursor.visible = true;
}
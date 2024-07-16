using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

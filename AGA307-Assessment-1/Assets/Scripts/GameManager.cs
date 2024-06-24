using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public GameDifficulty gameDifficulty;

    void Start()
    {
        gameState = GameState.Start;
    }

    
    void Update()
    {
        
    }
}

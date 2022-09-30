using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameOverScript GameOverScript;
    public int maxEnemy = 0;
    
    public void GameOver()
    {
        GameOverScript.Setup(maxEnemy);
    }
}

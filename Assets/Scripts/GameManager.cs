using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // graffiti
    public Text uiText;

    public Text killText;

    public int m_wave;

    public GameObject uiLevel;
    public GameObject uiBOSS;
    public GameObject uiEnd;
    public GameObject uiClose;
    public GameObject uiMenu;

    //states
    enum State { NotStarted, Playing, GameOver, WonGame }

    // current state
    State currState;

    // Enemy Manager
    EnemyManager enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        // start as not playing
        currState = State.NotStarted;

        // refresh UI
        RefreshUI();

        // find the enemy manager
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();

        // log error if it wasn't found
        if(enemyManager == null)
        {
            Debug.LogError("there needs to be an EnemyManager in the scene");
        }
    }

    void RefreshUI()
    {
        // act according to the state
        switch(currState)
        {
            case State.NotStarted:
                uiText.text = "Shoot here to begin";
                break;

            case State.Playing:
                uiText.text = "Enemies left: " + enemyManager.numEnemies;
                break;

            case State.GameOver:
                uiText.text = "Game Over! Shoot here";
                break;

            case State.WonGame:
                uiText.text = "YOU WON! Shoot here";
                break;
        }  
    }

    public void InitGame(int wave)
    {
        m_wave = wave;
        //don't initiate the game if the game is already running!
        if (currState == State.Playing) return;

        // set the state
        currState = State.Playing;

        // create enemy wave
        if (m_wave == 0)
        {
            enemyManager.CreateEnemyWave();
        }
        else if (m_wave == 1)
        {
            enemyManager.CreateBOSSWave();
            killText.text = "BOSS HP : " + enemyManager.bossHP.ToString() + "/ 1000";
        }

        // show text on the graffiti
        RefreshUI();
    }

    // game over
    public void GameOver()
    {
        // do nothing if we were already on game over
        if (currState == State.GameOver) return;

        // set the state to game over
        currState = State.GameOver;

        // show text on the graffiti
        RefreshUI();

        // remove all enemies
        enemyManager.KillAll();
    }

    // checks whether we've won, and if we did win, refresh UI
    public void HandleEnemyDead()
    {
        if (currState != State.Playing) return;

        RefreshUI();

        // have we won the game?
        if(enemyManager.numEnemies <= 0)
        {
            // set the state of the game
            currState = State.WonGame;

            // show text on the graffiti
            RefreshUI();

            // remove all enemies
            enemyManager.KillAll();
        }
    }

    public void CloseUI()
    {
        uiLevel.SetActive(false);
        uiBOSS.SetActive(false);
        uiEnd.SetActive(false);
        uiClose.SetActive(false);
        uiMenu.SetActive(true);
    }

    public void OpenUI()
    {
        uiLevel.SetActive(true);
        uiBOSS.SetActive(true);
        uiEnd.SetActive(true);
        uiClose.SetActive(true);
        uiMenu.SetActive(false);
    }
}

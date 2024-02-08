using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject winUI;
    [SerializeField] TMP_Text finalScoreUI;

    [SerializeField] Player player;
    [SerializeField] FloatVariable health;
    [SerializeField] FloatVariable score;
    [SerializeField] GameObject respawn;
     
    [Header("Events")]
    [SerializeField] Event _2XEvent;
    [SerializeField] Event gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;
    
    public enum State
    {
        TITLE,
        SET_GAME,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    private State state = State.TITLE;
    private float timer = 0;
    private int lives = 0;

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesUI.text = "LIVES: " + lives.ToString();
        }
    }

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            timerUI.text = string.Format("{0:F2}", timer);
        }
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                gameOverUI.SetActive(false);
                winUI.SetActive(false);
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.SET_GAME:
                winUI.SetActive(false);
                gameOverUI.SetActive(false);
                titleUI.SetActive(false);
                health.value = 100;
                player.Score = 0;
                state = State.START_GAME;
                Timer = 60;
                break;
            case State.START_GAME:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    state = State.GAME_OVER;
                }
                if (Input.GetKeyDown("i"))
                {
                    state = State.GAME_OVER;
                }
                break;
            case State.GAME_OVER:
                if (player.Score >= 750)
                {
                    winUI.SetActive(true);
                    finalScoreUI.text = "Final Score: " + player.Score;
                }
                else if (player.Score < 750)
                {
                    gameOverUI.SetActive(true);
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            default:
                break;
        }
    }

    public void OnStartGame()
    {
        state = State.SET_GAME;
        Lives = 3;
    }

    public void OnPlayerDead()
    {
        Lives = Lives - 1;
        if (!(Lives <= 0))
        {
            state = State.START_GAME;
        }
        else
        {
            state = State.GAME_OVER;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnTimeUp()
    {
        Timer = Timer + 10;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }
}
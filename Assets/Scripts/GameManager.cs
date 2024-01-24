using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;
    [SerializeField] GameObject respawn;

    [Header("Events")]
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
            timerUI.text = string.Format("{0:F1}", timer);
        }
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                gameOverUI.SetActive(false);
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.SET_GAME:
                gameOverUI.SetActive(false);
                titleUI.SetActive(false);
                Lives = 3;
                Timer = 60;
                state = State.START_GAME;
                break;
            case State.START_GAME:
                
                health.value = 100;
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
                break;
            case State.GAME_OVER:
                gameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            default:
                break;
        }
        healthUI.value = health / 100.0f;
    }

    public void OnStartGame()
    {
        state = State.SET_GAME;
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

    public void OnAddPoints(int points)
    {
        print(points);
    }
}

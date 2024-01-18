using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] TMP_Text scoreUI;

    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Timer = 60;
                Lives = 3;
                state = State.PLAY_GAME;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (timer <= 0)
                {
                    state = State.GAME_OVER;
                }
                break;
            case State.GAME_OVER:

                break;

            default:
                break;
        }
    }
    public void OnStartGame()
    {
        state = State.START_GAME;
    }
}

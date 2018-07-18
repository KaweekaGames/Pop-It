using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static bool created = false;
    public Text player1ScoreText;
    public Text player2ScoreText;

    //Get values from options menu
    public float setTimer = 30f;
    public int setMaxScore = 200;

    private float m_timer;
    public float Timer { get{return m_timer;} }

    private int m_player = 0;
    public int Player { get { return m_player; } }

    private int m_player1Score = 0;
    public int Player1Score { get { return m_player1Score; } }

    private int m_player2Score = 0;
    public int Player2Score { get { return m_player2Score; } }

    private int m_maxScore;
    public int MaxScore { get { return m_maxScore; } }

    private int m_round = 1;
    public int Round { get { return m_round; } }

    bool solved;
    PuzzleManager puzzleManager;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    private void Start()
    {
        m_timer = setTimer;
        m_maxScore = setMaxScore;
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void Update()
    {
        player1ScoreText.text = Player1Score.ToString();
        player2ScoreText.text = Player2Score.ToString();
    }

    public void CheckAnswer()
    {
        solved = puzzleManager.CheckAnswer();

        if (solved)
        {
            //EndRound
        }
        else
        {
            m_player = 1 - Player;
            m_round++;
        }
    }

    public void AddScore()
    {
        if(Player == 0)
        {
            if (Round < 5)
            {
                m_player1Score = Player1Score + (12 - 2 * Round); 
            }
            else
            {
                m_player1Score = Player1Score + 2;
            }
        }
        else
        {
            if (Round < 5)
            {
                m_player2Score = Player2Score + (12 - 2 * Round);
            }
            else
            {
                m_player2Score = Player2Score + 2;
            }
        }
    }
}

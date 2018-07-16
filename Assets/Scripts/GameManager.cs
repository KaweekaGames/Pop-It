using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool created = false;

    //Get values from options menu
    public float setTimer = 30f;
    public int setMaxScore = 200;

    private float m_timer;
    public float Timer { get{return m_timer;} }

    private int m_player = 1;
    public int Player { get { return m_player; } }

    private int m_player1Score = 0;
    public int Player1Score { get { return m_player1Score; } }

    private int m_player2Score = 0;
    public int Player2Score { get { return m_player2Score; } }

    private int m_maxScore;
    public int MaxScore { get { return m_maxScore; } }

    private int m_round = 1;
    public int Round { get { return m_round; } }

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
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int m_difficulty;
    public int Difficulty { get{return m_difficulty;}}

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public void SetDifficulty(int x)
    {
        m_difficulty = x;
    }
}

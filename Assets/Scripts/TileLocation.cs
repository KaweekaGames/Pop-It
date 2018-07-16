using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLocation : MonoBehaviour
{
    public bool occupied = false;

    char m_value;
    public char Value { get { return m_value; } }

    Vector2 m_position;
    public Vector2 Position { get { return m_position; }}


    private void Start()
    {
        m_position = transform.position;
    }


    public void AssignValue(char letter)
    {
        m_value = letter;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTile : MonoBehaviour
{
    public float time = .3f;
    public float constantMoveTime = .1f;
    public float delay = .3f;
    public Vector3 newPosition;
    public EaseType moveEase;
    public string colliderTag;
    public Sprite[] sprites;

    [SerializeField]
    public bool locked = false;

    SpriteRenderer spriteRen;
    Vector2 targetPos;
    Vector2 parkedPos;
    bool touched = false;
    bool parked = false;
    BoxCollider2D boxCol;

    [SerializeField]
    char m_value;
    public char Value { get { return m_value; }}

    bool m_correct = false;
    public bool Correct { get { return m_correct; } }

    Vector2 m_homePos;
    public Vector2 HomePos { get{return m_homePos; } }

    // Update is called once per frame
    void Awake()
    {
        targetPos = transform.position;
        m_homePos = transform.position;
        spriteRen = this.GetComponent<SpriteRenderer>();
        //boxCol = GetComponent<BoxCollider2D>();
        //boxCol.isTrigger = false;
    }

    private void Update()
    {
        if (touched && !locked)
        {
            gameObject.MoveUpdate(targetPos, constantMoveTime);
        }
    }

    void OnTouchDown()
    {
        touched = true;
    }

    void OnTouchUp()
    {
        touched = false;
        if (parked && !locked)
        {
            gameObject.MoveTo(parkedPos, time, delay);
        }

        else if (!locked)
        {
            gameObject.MoveTo(m_homePos, time, delay, moveEase);
        }
    }

    void OnTouchStay(Vector2 point)
    {
        if (!locked)
        {
            targetPos = point; 
        }
    }

    void OnTouchCancel()
    {
        touched = false;
        if (parked && !locked)
        {
            gameObject.MoveTo(parkedPos, time, delay);
        }

        else if(!locked)
        {
            gameObject.MoveTo(m_homePos, time, delay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == colliderTag)
        {
            TileLocation tileLoc = collision.GetComponent<TileLocation>();

            if (!tileLoc.occupied)
            {
                parkedPos = tileLoc.Position;
                parked = true;
                tileLoc.occupied = true;

                if(tileLoc.Value == Value)
                {
                    m_correct = true;
                } 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == colliderTag)
        {
            TileLocation tileLoc = collision.GetComponent<TileLocation>();

            if (tileLoc.occupied && parked)
            {
                parked = false;
                tileLoc.occupied = false;
                m_correct = false;
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == colliderTag)
    //    {
    //        TileLocation tileLoc = collision.GetComponent<TileLocation>();

    //        if (!tileLoc.occupied)
    //        {
    //            parkedPos = tileLoc.Position;
    //            parked = true;
    //            tileLoc.occupied = true;
    //        }
    //    }
    //}

    public void AssignValue(char letter)
    {
        m_value = letter;

        switch (m_value)
        {
            case 'A':
                spriteRen.sprite = sprites[0];
                break;

            case 'B':
                spriteRen.sprite = sprites[1];
                break;

            case 'C':
                spriteRen.sprite = sprites[2];
                break;

            case 'D':
                spriteRen.sprite = sprites[3];
                break;

            case 'E':
                spriteRen.sprite = sprites[4];
                break;

            case 'F':
                spriteRen.sprite = sprites[5];
                break;

            case 'G':
                spriteRen.sprite = sprites[6];
                break;

            case 'H':
                spriteRen.sprite = sprites[7];
                break;

            case 'I':
                spriteRen.sprite = sprites[8];
                break;

            case 'J':
                spriteRen.sprite = sprites[9];
                break;

            case 'K':
                spriteRen.sprite = sprites[10];
                break;

            case 'L':
                spriteRen.sprite = sprites[11];
                break;

            case 'M':
                spriteRen.sprite = sprites[12];
                break;

            case 'N':
                spriteRen.sprite = sprites[13];
                break;

            case 'O':
                spriteRen.sprite = sprites[14];
                break;

            case 'P':
                spriteRen.sprite = sprites[15];
                break;

            case 'Q':
                spriteRen.sprite = sprites[16];
                break;

            case 'R':
                spriteRen.sprite = sprites[17];
                break;

            case 'S':
                spriteRen.sprite = sprites[18];
                break;

            case 'T':
                spriteRen.sprite = sprites[19];
                break;

            case 'U':
                spriteRen.sprite = sprites[20];
                break;

            case 'V':
                spriteRen.sprite = sprites[21];
                break;

            case 'W':
                spriteRen.sprite = sprites[22];
                break;

            case 'X':
                spriteRen.sprite = sprites[23];
                break;

            case 'Y':
                spriteRen.sprite = sprites[24];
                break;

            case 'Z':
                spriteRen.sprite = sprites[25];
                break;

            default:
                spriteRen.sprite = sprites[26];
                break;
        }
    }

    public void SendHome()
    {
        locked = false;
        gameObject.MoveTo(HomePos, time, delay, moveEase);
        m_correct = false;
    }

    public void Reset()
    {
        transform.position = HomePos;
        m_correct = false;
        parked = false;
        locked = false;
        gameObject.SetActive(false);
    }
}

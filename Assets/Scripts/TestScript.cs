using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestScript : MonoBehaviour
{
    public float time = .3f;
    public float constantMoveTime = .1f;
    public float delay = .3f;
    public Vector3 newPosition;
    public Vector3 scale;
    public EaseType moveEase;
    public EaseType scaleEase;
    public string colliderTag;

    private SpriteRenderer spriteRen;
    private Vector3 originalScale;
    private Vector2 targetPos;
    private Vector2 homePos;
    private Vector2 parkedPos;
    private bool touched = false;
    public bool parked = false;
    private List<GameObject> objects = new List<GameObject>();

    // Update is called once per frame
    void Awake()
    {
        originalScale = transform.localScale;
        targetPos = transform.position;
        homePos = transform.position;
        spriteRen = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (touched)
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
        if (parked)
        {
            gameObject.MoveTo(parkedPos, time, delay);
        }

        else
        {
            gameObject.MoveTo(homePos, time, delay, moveEase);
        }
    }

    void OnTouchStay(Vector2 point)
    {
        targetPos = point;
    }

    void OnTouchCancel()
    {
        touched = false;
        if (parked)
        {
            gameObject.MoveTo(parkedPos, time, delay);
        }

        else
        {
            gameObject.MoveTo(homePos, time, delay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == colliderTag)
        {
            letter let = collision.GetComponent<letter>();

            if (!let.occupied && objects.Count<=0)
            {
                parkedPos = collision.gameObject.transform.position;
                parked = true;
                collision.GetComponent<letter>().occupied = true;
                objects.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == colliderTag)
        {
            letter let = collision.GetComponent<letter>();

            if (let.occupied && parked)
            {
                parked = false;
                collision.GetComponent<letter>().occupied = false;
                objects.Remove(collision.gameObject);
            } 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == colliderTag)
        {
            letter let = collision.GetComponent<letter>();

            if (!let.occupied && objects.Count <= 0)
            {
                parkedPos = collision.gameObject.transform.position;
                parked = true;
                collision.GetComponent<letter>().occupied = true;
                objects.Add(collision.gameObject);
            }
        }
    }
}

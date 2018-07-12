using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestScript : MonoBehaviour
{
    public float time = 1f;
    public float delay = .5f;
    public Vector3 newPosition;
    public Vector3 scale;
    public EaseType moveEase;
    public EaseType scaleEase;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.MoveTo(newPosition, time, delay, moveEase);
        gameObject.ScaleTo(scale, time, delay, scaleEase);
    }
}

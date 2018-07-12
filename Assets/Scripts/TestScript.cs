using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestScript : MonoBehaviour
{
    public string fileName;

    SpriteRenderer spriteRenderer;
   
    
    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        string[] lines = File.ReadAllLines(fileName);

        string color = lines[0];

        if (color == "red")
        {
            spriteRenderer.color = Color.red; 
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

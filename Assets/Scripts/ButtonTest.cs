using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{

    public Text text;

    public PuzzleManager puzzle;
    
    public void Test()
    {
        puzzle.StartRound();
        text.text = puzzle.Category;

    }
}

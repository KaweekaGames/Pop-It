using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    string m_word;
    public string Word { get{return m_word;}}

    string m_category;
    public string Category { get {return m_category; } }

    string[] selectedWord;
    string[] wordList;
    List<string> usedWords = new List<string>();
    List<char> puzzleRandomized = new List<char>();
    char[] puzzle;
    int startLoc;
    GameManager gameManager;

    [SerializeField]
    string fileName;

    public TileLocation[] locationTiles;
    public LetterTile[] letterTiles;
    public char[] alphabet;

    void Awake()
    {
        wordList = File.ReadAllLines(fileName);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void StartRound()
    {
        ResetTiles();

        puzzle = GetPuzzle();

        puzzleRandomized = RandomizePuzzle(puzzle);

        //Find how many empty tiles will exist
        int diff = locationTiles.Length - m_word.Length;

        //Determin starting location based on number of empty tiles
        switch (diff)
        {
            case 0:
            case 1:
                startLoc = 0;
                break;

            case 2:
            case 3:
                startLoc = 1;
                break;

            case 4:
            case 5:
                startLoc = 2;
                break;

            case 6:
            case 7:
                startLoc = 3;
                break;

            default:
                startLoc = 0;
                break;
        }

        int tempCount = startLoc;

        for (int i = 0; i < puzzle.Length; i++)
        {
            locationTiles[tempCount].gameObject.SetActive(true);
            locationTiles[tempCount].AssignValue(puzzle[i]);
            tempCount++;
        }

        for (int i = 0; i < puzzleRandomized.Count; i++)
        {
            letterTiles[startLoc].gameObject.SetActive(true);
            letterTiles[startLoc].AssignValue(puzzleRandomized[i]);
            startLoc++;
        }

    }

    public bool CheckAnswer()
    {
        bool allCorrect = true;

        foreach(LetterTile lT in letterTiles)
        {
            if (lT.Correct && !lT.locked)
            {
                gameManager.AddScore();
                lT.locked = true;
            }
            else if (!lT.locked)
            {
                allCorrect = false;
                lT.SendHome();
            }
        }

        return allCorrect;
    }

    private char [] GetPuzzle()
    {
        do
        {
            selectedWord = GetWord(wordList);

            m_word = selectedWord[0];
            m_category = selectedWord[1]; 

        } while (m_word.Length > locationTiles.Length);

        return m_word.ToCharArray();
    }

    private string[] GetWord(string[] words)
    {
        bool newWord = false;
        string chosenWord = null;

        while (!newWord)
        {
            int randNumber = Random.Range(0, words.Length);

           chosenWord = words[randNumber];

            if (usedWords != null)
            {
                if (!usedWords.Contains(chosenWord))
                {
                    newWord = true;

                    if (usedWords.Count < (words.Length)-1)
                    {
                        usedWords.Add(chosenWord);
                    }
                    else
                    {
                        usedWords = new List<string>();
                    }
                }
                else
                {
                    newWord = false;
                }
            }
            else
            {
                newWord = true;
                usedWords.Add(m_word);
            }
        }

        string [] splitWord = chosenWord.Split(';');

        return splitWord;
    }

    private void ResetTiles()
    {
        foreach(TileLocation tL in locationTiles)
        {
            tL.Reset();
        }

        foreach(LetterTile lT in letterTiles)
        {
            lT.Reset();
        }
    }

    private List<char> RandomizePuzzle(char[] puz)
    {
        List<char> puzzleList = new List<char>();
        List<char> randomPuzzle = new List<char>();
        int letterCount;

        foreach(char ch in puz)
        {
            puzzleList.Add(ch);
        }

        int rand;

        do
        {
            rand = Random.Range(0, alphabet.Length); 
        } while (rand == 16 || rand == 21 || rand == 23 || rand == 24 || rand == 25);

        puzzleList.Add(alphabet[rand]);

        letterCount = puzzleList.Count;

        do
        {
            int ran = Random.Range(0, puzzleList.Count);
            randomPuzzle.Add(puzzleList[ran]);
            puzzleList.RemoveAt(ran);
        }
        while (randomPuzzle.Count < letterCount);

        return randomPuzzle;
    }
}

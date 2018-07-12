using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    string m_word;
    public string Word { get{return m_word;}}

    string[] easyWords;
    string[] hardWords;
    List<string> usedWords = new List<string>();

    public string easyFile;
    public string hardFile;
    string fileName;

    int difficulty;

    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        easyWords = File.ReadAllLines(easyFile);
        hardWords = File.ReadAllLines(hardFile);
    }

    public string ReturnWord()
    {
        difficulty = gameManager.Difficulty;

        if (difficulty == 0)
        {
            m_word = GetWord(easyWords);
        }
        else
        {
            m_word = GetWord(hardWords);
        }

        return Word;
    }

    private string GetWord(string[] words)
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

                    if (usedWords.Count < (words.Length - 1))
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

        return chosenWord;
    }
}

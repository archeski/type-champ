using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordParser : MonoBehaviour {

    private static  List<string> wordList = ReadWords();

    private static List<string> ReadWords()
    {
        List<string> temp = new List<string>();

        using (StreamReader sr = new StreamReader("words.txt"))
        {
            while (!sr.EndOfStream)
                temp.Add(sr.ReadLine());
        }

        return temp;
    }

    public static string GetRandomWord()
    {
        uint index = (uint)Random.Range(0,wordList.Count);

        string randomWord = wordList[(int)index];

        return randomWord;
    }
 
}

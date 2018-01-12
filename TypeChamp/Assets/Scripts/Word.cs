using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {

    public decimal score = 0;
    public string text;
    private int index;
	
	WordDisplayer  displayer;

    public Word (string word, WordDisplayer displayer)
    {
        this.text = word;
		this.displayer = displayer;
        index = 0;
		
		displayer.SetWord(word);
		
    }

    public char GetNextLetter()
    {
        return text[index];
    }
	
    public bool IsTyped()
    {
        if (index >=text.Length)
        {
            displayer.RemoveWord();
            score += 10;
            return true;
        }
        return false;
 
    }

    public void LetterIsTyped()
    {
        index++;
        //Remove the letter on the screen
        displayer.RemoveLetter();
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public WordSpawner spawner;
    public List<Word> words;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI faultsText;
    private bool isActive = false;
    private bool isChanged = false;
    private int levelBound = 100;
    private Word activeWord;
    
    public int scoreMultiplier = 1;
    public int faults = 5;
    public int score = 0;
    
    private void Update()
    {
        
        scoreText.text = "Score: " + score;
        faultsText.text = "Faults left: " + faults;
        if (score == levelBound && isChanged == false)
        {
            scoreMultiplier++;
            levelBound = (int)Mathf.Pow(10f, (float)scoreMultiplier);
            
            levelText.text = "Rich " + levelBound + " points";
            isChanged = true;
        }
        else if (score != levelBound && isChanged == true)
        {
            isChanged = false;
        }
        
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(),spawner.SpawnWord());
        words.Add(word);
        Debug.Log("Random word was spawned succesfully : " + word.text);
    }

    public void TypeSymbol(char symbol)
    {
        if (char.IsLetter(symbol) || char.IsWhiteSpace(symbol))
        {
            if (isActive)
            {
                if (activeWord.GetNextLetter() == symbol)
                {
                    activeWord.LetterIsTyped();
                }

            }
            else
            {
                Word currentWord = words.Find(word => word.GetNextLetter() == symbol);
                if (currentWord.GetNextLetter() == symbol)
                {
                    activeWord = currentWord;
                    isActive = true;
                    currentWord.LetterIsTyped();
                }

            }

            if (isActive && activeWord.IsTyped())
            {
                
                isActive = false;
                words.Remove(activeWord);
                
                score += 10 * scoreMultiplier;
            }
        }
    }

   
}

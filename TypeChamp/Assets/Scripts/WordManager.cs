using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public WordSpawner spawner;
    public List<Word> words;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public float spawnDelay = 10f;
    public int scoreMultiplier = 1;
    public int score = 0;
    private bool isActive = false;
    private bool isChanged = false;
    private int levelBound = 100;
    private Word activeWord;
    private float nextWordTime = 0f;
    
    private void Update()
    {
        foreach (var letter in Input.inputString)
        {
            TypeSymbol(letter);
            Debug.Log("Letter " + letter + " was typed");
        }

        scoreText.text = "Score: " + score;
        
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

        if (Time.time >= nextWordTime)
        {
            AddWord();
            nextWordTime = Time.time + spawnDelay;
        }

    }

    public void AddWord()
    {
        Word word = new Word(WordParser.GetRandomWord(),spawner.SpawnWord());
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

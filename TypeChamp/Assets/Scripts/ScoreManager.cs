using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public WordManager wordManager;
    public int scoreMultiplier = 2;

    void Update ()
    {
        int levelBound = 100;
        bool isChanged = false;

        scoreText.text = "Score: " + wordManager.score * scoreMultiplier;
        
        if (wordManager.score == levelBound && isChanged == false)
        {
            levelBound = ((int)Mathf.Pow(10f, (float)scoreMultiplier))/2*scoreMultiplier;
            scoreMultiplier++;
            isChanged = true;
        }
        else if (wordManager.score != levelBound && isChanged == true)
        {
            isChanged = false;
        }
  
    }
}

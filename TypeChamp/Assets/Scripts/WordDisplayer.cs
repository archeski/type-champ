using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplayer : MonoBehaviour {

    public TextMeshProUGUI wordTextPrefab;
    public float fallSpeed = 60f;
    
    public void SetWord (string word)
    {
        wordTextPrefab.text = word;


        //determine how to change text gradient 
        //wordTextPrefab.colorGradient = TMP_ColorGradient;
        //if (word.Length <= 7 && word.Length >= 4)
        //    wordTextPrefab.color = Color.green;
        //else if (word.Length >7)
        //    wordTextPrefab.color = Color.cyan;
    }

    public void RemoveLetter()
    {
        wordTextPrefab.text = wordTextPrefab.text.Remove(0, 1);
        wordTextPrefab.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    void Update ()
    {
        //Need to add dependence between falling and spawning a new word
        //Word falling doesn't work properly
        transform.Translate(0f, (-fallSpeed * Time.deltaTime)/2, 0f);

        if (gameObject.transform.position.y <= -350f)
            RemoveWord();

        fallSpeed/= 0.999f; 

	}
}

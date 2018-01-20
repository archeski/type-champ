using TMPro;
using UnityEngine;

public class WordDisplayer : MonoBehaviour {

    public TextMeshProUGUI wordTextPrefab;
    public float fallSpeed = 60f;


    public void SetWord (string word)
    {
        wordTextPrefab.text = word;
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
        {
            RemoveWord();
        }
 
	}
}

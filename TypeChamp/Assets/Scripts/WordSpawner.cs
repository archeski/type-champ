using UnityEngine;

public class WordSpawner : MonoBehaviour {

    public GameObject wordPrafab;
    public Transform canvas;
 

    public WordDisplayer SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-50f, 500f),400f);

        GameObject newWord = Instantiate(wordPrafab,randomPosition,Quaternion.identity, canvas);

        WordDisplayer wordDisplayer = newWord.GetComponent<WordDisplayer>();
      

        return wordDisplayer;
    }
}

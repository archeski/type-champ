using UnityEngine;

public class TypeManager : MonoBehaviour {

    public WordManager wordManager;

	void Update ()
    {
	    foreach (var letter in Input.inputString)
        {
            wordManager.TypeSymbol(letter);    
            Debug.Log("Letter " + letter + " was typed");
        }
	}
}

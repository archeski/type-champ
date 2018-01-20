[System.Serializable]
public class Word {

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
            return true;
        }
        return false;
 
    }

    public void LetterIsTyped()
    {   
        //Remove letter on the screen
        displayer.RemoveLetter();
        index++;
    }
}

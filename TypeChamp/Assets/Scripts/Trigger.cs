using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour {

    private int lives = 5;
    public TextMeshProUGUI faultsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Word"))
        {
            if (lives<=0)
            {
                //End game
            }

            lives--;
            faultsText.text = "Faults left: " + lives;
        }
    }
}

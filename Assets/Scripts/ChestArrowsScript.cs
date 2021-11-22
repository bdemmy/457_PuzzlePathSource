using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestArrowsScript : MonoBehaviour
{
    // Private references
    Text ButtonText;

    private void Awake() {
        ButtonText = GetComponent<Text>();
    }

    public void OnClick(int direction) {
        int currentCharacter = ButtonText.text[0] - 'A';
        currentCharacter += direction;
        if (currentCharacter < 0) {
            currentCharacter += 26;
        }
        currentCharacter %= 26;
        currentCharacter += 'A';
        ButtonText.text = ((char)currentCharacter).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;   //trying to work with canvas images, not sprites. Use the selected option to know what image to enable/disable

    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption); 
    }
    
    public void NextOption()
    {
        selectedOption++;
        if(selectedOption > characterDB.characterCount)
        {
            selectedOption = 0; //resets to start 
        }
        UpdateCharacter(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;
        
        if(selectedOption < 0)
        {
            selectedOption = characterDB.characterCount - 1;
        }
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

}
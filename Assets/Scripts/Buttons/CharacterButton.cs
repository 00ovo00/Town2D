using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField]
    private Image characterImage;
    [SerializeField]
    private GameObject characterMenu;
    [SerializeField]
    private Image choiceImage;

    public void OnChooseCharacter()
    {
        characterImage.sprite = choiceImage.sprite;
        characterMenu.SetActive(false);
    }
}

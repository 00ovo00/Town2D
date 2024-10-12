using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoiceButton : MonoBehaviour
{
    [SerializeField]
    private GameObject characterMenu;
    public void OnCharacterChoice()
    {
        characterMenu.SetActive(true);
    }
}

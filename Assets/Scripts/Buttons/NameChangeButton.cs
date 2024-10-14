using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameChangeButton : MonoBehaviour
{
    [SerializeField]
    private GameObject nameChangeMenu;

    public void OnNameChange()
    {
        nameChangeMenu.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ConfirmButton : MonoBehaviour
{
    public static event Action OnNameChange;

    [SerializeField]
    private InputField inputName;
    [SerializeField]
    private GameObject changeNameMenu;

    public void Confirm()
    {
        PlayerPrefs.SetString("Name", inputName.text);
        changeNameMenu.SetActive(false);
        OnNameChange?.Invoke();  // 이름 변경 함수 호출
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettingManager : MonoBehaviour
{
    [SerializeField]
    private Text playerName;

    // 플레이어 생성 후 플레이어에 붙어있는 스크립트로 동작해야 오류 X
    void Start()
    {
        // 이름 세팅
        if (PlayerPrefs.HasKey("Name"))
        {
            playerName.text = PlayerPrefs.GetString("Name");
        }
    }
}
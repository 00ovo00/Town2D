using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettingManager : MonoBehaviour
{
    [SerializeField]
    private Text playerName;

    // �÷��̾� ���� �� �÷��̾ �پ��ִ� ��ũ��Ʈ�� �����ؾ� ���� X
    void Start()
    {
        // �̸� ����
        if (PlayerPrefs.HasKey("Name"))
        {
            playerName.text = PlayerPrefs.GetString("Name");
        }
    }
}
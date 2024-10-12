using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

enum PlayerType
{
    Penguin,
    Wizard,
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameObject playerPrefab;

    public static GameManager Instance
    {
        // �ν��Ͻ� ������ GameManager Ÿ���� ������Ʈ ��������
        get
        {
            if (!instance)
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            return instance;
        }
    }

    private void Awake()
    {
        // �ν��Ͻ� ������ �� ������Ʈ�� �ν��Ͻ��� ����
        if (instance == null)
        {
            instance = this;
        }
        // �ν��Ͻ� ������ ���� ������ ���� �ʿ�����Ƿ� �ı�
        else
        {
            Destroy(gameObject);
        }
        // ���� �Ѿ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);

        InstantiatePlayer();
    }
    private void InstantiatePlayer()
    {
        // Ÿ�Կ� ���� �ٸ� �÷��̾� ����
        if (PlayerPrefs.HasKey("Type"))
        {
            int type = PlayerPrefs.GetInt("Type") - '0';
            PlayerType playertype = (PlayerType)Enum.Parse(typeof(PlayerType), type.ToString());
            GameObject go;
            switch (playertype)
            {
                case PlayerType.Penguin:
                    playerPrefab = Resources.Load("Prefabs/Penguin", typeof(GameObject)) as GameObject;
                    go = PrefabUtility.InstantiatePrefab(playerPrefab) as GameObject;
                    break;
                case PlayerType.Wizard:
                    playerPrefab = Resources.Load("Prefabs/Wizard", typeof(GameObject)) as GameObject;
                    go = PrefabUtility.InstantiatePrefab(playerPrefab) as GameObject;
                    break;
            }
        }
    }
}

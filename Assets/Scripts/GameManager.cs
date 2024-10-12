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
        // 인스턴스 없으면 GameManager 타입의 오브젝트 가져오기
        get
        {
            if (!instance)
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            return instance;
        }
    }

    private void Awake()
    {
        // 인스턴스 없으면 이 오브젝트를 인스턴스로 만듦
        if (instance == null)
        {
            instance = this;
        }
        // 인스턴스 있으면 새로 생성된 것은 필요없으므로 파괴
        else
        {
            Destroy(gameObject);
        }
        // 씬이 넘어가도 파괴되지 않도록 관리
        DontDestroyOnLoad(gameObject);

        InstantiatePlayer();
    }
    private void InstantiatePlayer()
    {
        // 타입에 따라 다른 플레이어 생성
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

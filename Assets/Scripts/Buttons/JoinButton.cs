using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
    [SerializeField]
    private InputField inputName;
    [SerializeField]
    private Image characterImage;

    public void Join()
    {
        // 플레이어 이름과 캐릭터 타입을 저장
        int playerType = FindCharaterType();
        PlayerPrefs.SetInt("Type", playerType);
        PlayerPrefs.SetString("Name", inputName.text);
        // 다음씬으로 이동
        SceneManager.LoadScene("MainScene");
    }
    private int FindCharaterType()
    {
        // 캐릭터 이미지 파일 이름으로부터 타입 가져오기
        int type = characterImage.sprite.name[0];
        return type;
    }
}

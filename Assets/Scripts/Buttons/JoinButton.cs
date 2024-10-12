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
        // �÷��̾� �̸��� ĳ���� Ÿ���� ����
        int playerType = FindCharaterType();
        PlayerPrefs.SetInt("Type", playerType);
        PlayerPrefs.SetString("Name", inputName.text);
        // ���������� �̵�
        SceneManager.LoadScene("MainScene");
    }
    private int FindCharaterType()
    {
        // ĳ���� �̹��� ���� �̸����κ��� Ÿ�� ��������
        int type = characterImage.sprite.name[0];
        return type;
    }
}

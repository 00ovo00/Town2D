using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text timeTxt;   // ���� �ð� ǥ���ϴ� �ؽ�Ʈ
    void Awake()
    {
        timeTxt = GetComponent<Text>();
    }

    void Update()
    {
        // ���� �ð� �д����� ����
        timeTxt.text = TimeUtils.GetCurrentDate();
    }
}

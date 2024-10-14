using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text timeTxt;   // 현재 시각 표시하는 텍스트
    void Awake()
    {
        timeTxt = GetComponent<Text>();
    }

    void Update()
    {
        // 현재 시각 분단위로 갱신
        timeTxt.text = TimeUtils.GetCurrentDate();
    }
}

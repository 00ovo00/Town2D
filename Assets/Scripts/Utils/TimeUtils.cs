using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils
{
    // 현재 시각을 분:초 포맷으로 가져오기
    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString(("HH:mm"));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils
{
    // ���� �ð��� ��:�� �������� ��������
    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString(("HH:mm"));
    }
}

using UnityEngine;
using System.Collections;
using System;

public class NightStatus : csvlord
{
    [Header("クリアラウンドに対して植える星")]
    public int[] upstar;
    [Header("クリアラウンドに対して植える人")]
    public int[] uphuman;

    [Header("増える値 0 星' 1 人' 2 ラウンド")]
    private int[] upstatus;

    void Awake()
    {
        Array.Resize(ref upstatus, 3);
        CSVRead();
        upstatus[0] = upstar[status[2]];
        upstatus[1] = uphuman[status[2]];
        upstatus[2] = 1;
        CSVInput(upstatus);
    }
}
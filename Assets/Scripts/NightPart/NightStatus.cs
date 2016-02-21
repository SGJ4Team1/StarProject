using UnityEngine;
using System.Collections;

public class NightStatus : csvlord
{

    [Header("増える値 0 星' 1 人' 2 ラウンド")]
    public int[] upstatus;

    void Awake()
    {
        CSVRead();
        CSVInput(upstatus);
    }
}
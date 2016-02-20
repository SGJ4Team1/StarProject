using UnityEngine;
using System.Collections;

public class NightManager : MonoBehaviour
{
    csvlord csv;
    [Header("星の数")]
    public int star;

    void Start()
    {
        csv = transform.GetComponent<csvlord>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            star = csv.StarRead();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            star = csv.StarUp();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            star = csv.StarReset();
        }
    }
}
using UnityEngine;
using System.Collections;
using System;

public class GameTimer : MonoBehaviour, GameClearHandlar
{
    [SerializeField]
    private GameManager gameManager;
    public float time;

	// Use this for initialization
	void Start ()
    {
	    StartTimer();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void StartTimer()
    {
        StartCoroutine(TimeUpdate());
    }

    public void StopTimer()
    {
        StopCoroutine(TimeUpdate());
    }

    IEnumerator TimeUpdate()
    {
        while(true)
        {
            time -= Time.deltaTime;

            if(time <= 0)
            {
                break;
            }

            yield return null;
        }
        gameManager.GameOver();
    }

    public void AddTime(float add)
    {
        time += add;
    }

    public void SubTime(float sub)
    {
        time -= sub;
    }

    public void OnGameClear()
    {
        StopTimer();
    }
}

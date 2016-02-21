using UnityEngine;
using System.Collections;
using System;

public class DustRest : MonoBehaviour, GameOverHandlar
{
    [SerializeField]
    private int dustRest;

    [SerializeField]
    private GameManager manager;

    public bool isLock = false;

    public int Rest
    {
        get {return dustRest; }
    }

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Sub()
    {
        if(isLock)
        {
            return;
        }
        dustRest--;
        CheckRest();
    }

    void CheckRest()
    {
        if(dustRest <= 0)
        {
            manager.Clear();
        }
    }

    public void OnGameOver()
    {
        isLock = true;
    }
}

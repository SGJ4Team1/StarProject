using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameManager))]
public class StageReader : csvlord
{
    int stage;

    public int Stage
    {
        get{return stage; }
    }

	// Use this for initialization
	void Start ()
    {
	    CSVRead();
        stage = status[2];
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}

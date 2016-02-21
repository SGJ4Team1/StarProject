using UnityEngine;
using System.Collections;

public class StageReader : csvlord
{
    int stage;

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

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTimer : MonoBehaviour
{
    [SerializeField]
    GameTimer timer;

    Text text;

	// Use this for initialization
	void Start ()
    {
	    text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    text.text = "じかん:" + ((int)timer.time).ToString();
	}
}

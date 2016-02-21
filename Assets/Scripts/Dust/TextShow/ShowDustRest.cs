using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowDustRest : MonoBehaviour
{
    [SerializeField]
    DustRest dustRest;
    Text text;

	// Use this for initialization
	void Start ()
    {
	    text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    text.text = "Rest : " + dustRest.Rest.ToString();
	}
}

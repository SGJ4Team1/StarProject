using UnityEngine;
using System.Collections;

public class DustRest : MonoBehaviour
{
    [SerializeField]
    private int dustRest;

    [SerializeField]
    private GameManager manager;

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
}

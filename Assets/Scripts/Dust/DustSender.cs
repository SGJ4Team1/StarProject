using UnityEngine;
using System.Collections;

public class DustSender : MonoBehaviour
{
    [SerializeField]
    DustCreator creator;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void RandomPosition(GameObject dust)
    {
        dust.transform.position = creator.RandomPosition();
    }
}

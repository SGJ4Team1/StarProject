using UnityEngine;
using System.Collections;

public class TitlePartAnimation : MonoBehaviour {

    Animator animParts;

    // public
	public int NUM_OF_PAGES = 3;
    public string ANIMATION_PHASE = "phase";

	// Use this for initialization
	void Start () {
        animParts = GetComponent<Animator>();
        animParts.SetInteger(ANIMATION_PHASE, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeRequest()
    {
        Debug.Log( ANIMATION_PHASE + " phase : " + animParts.GetInteger(ANIMATION_PHASE));

        int phase = animParts.GetInteger(ANIMATION_PHASE);
        if (phase < NUM_OF_PAGES)
        {
            phase++;
            animParts.SetInteger(ANIMATION_PHASE, phase);
        }
    }
}

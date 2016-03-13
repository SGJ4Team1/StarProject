using UnityEngine;
using System.Collections;

public class TitlePartAnimation : MonoBehaviour {

    Animator animParts;

// public :
	public int NUM_OF_PAGES = 3;
    public string ANIMATION_PHASE = "phase";

// private :
	private bool _animation_finished = true;

	// Use this for initialization
	void Start () {
        animParts = GetComponent<Animator>();
        animParts.SetInteger(ANIMATION_PHASE, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Animation Change Request
    public void ChangeRequest()
    {
		// Callbackを返さないこともある(setIntegerでアニメーションしない場合。)のでflagcheckはしない
				
        int phase = animParts.GetInteger(ANIMATION_PHASE);
        if (phase < NUM_OF_PAGES)
        {
            phase++;
            animParts.SetInteger(ANIMATION_PHASE, phase);
			_animation_finished = false;
        }
    }

	// Animation Finished Callback
	public void CallbackEvent()
	{
		_animation_finished = true;
	}

	// Check Animation Finished
	public bool CheckAnimationFinished()
	{
		return _animation_finished;
	}
}

using UnityEngine;
using System.Collections;

namespace Inner
{
	
}

public class FadeManager : MonoBehaviour {
	
	public string ANIMATION = "EnterFade";

// private :
	private bool _animationFinished = true;
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = this.GetComponent<Animator>();
		_animator.SetBool( ANIMATION, false );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool FadeIn( bool fadeIn = true ) {
		if( !_animationFinished ) {
			// previous fade is not finished yet!
			return false;
		}
		PrintDebug( fadeIn ? "FadeIn" : "FadeOut" );
		_animator.SetBool( ANIMATION, fadeIn );
		_animationFinished = false;
		return true;
	}

	public bool FadeOut() {
		return FadeIn( false );
	}

	public bool CheckFadeFinish() { return _animationFinished; }

	void CallbackEvent() {
		PrintDebug("Callback");
		_animationFinished = true;
	}

	void PrintDebug( string text )
	{
		if( false ) {
			Debug.Log( text );
		}
	}
}

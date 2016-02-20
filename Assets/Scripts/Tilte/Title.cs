using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

// public :
    public Sprite introBG;

// private const
	private const int WINDOW_X = 720;
	private const int WINDOW_Y = 1280;

// private :
    private enum ePhase
    {
        ePhase_Wait  = 0,
        ePhase_Paging   ,
    };
    private ePhase _phase;
	private int _page = 0;
    private bool _is_android = true;

	// Use this for initialization
	void Start () 
	{
        SetBehavior();
		
    }
	
	// Update is called once per frame
	void Update () {

		if ((_is_android && Input.touchCount > 0)
             || (!_is_android && Input.GetMouseButtonDown(0)) )
        {
			SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
			renderer.sprite = introBG;
		}
	}

    void SetBehavior()
    {
        if(false == Application.isMobilePlatform )
        {
            _is_android = false;
        }
    }

	private class ScrollAnimation
	{
		// private const 
		private const int START_X = -1 * WINDOW_X;
		private const int END_X = 0;
		private const float v_x = 10.0f;
		
		// publicでいいか
		public float current_x = START_X;

		// public :
		public void InitAniation( ref GameObject obj )
		{
			current_x = START_X;
			obj.transform.Translate( current_x, obj.transform.position.y, 0.0f );
		}

		public void UpdateAnimation( ref GameObject obj )
		{
			current_x += v_x;
			if( END_X < current_x )
			{
				current_x = END_X;
			}	

			obj.transform.Translate( current_x, obj.transform.position.y, 0.0f );
		}

		public bool AnimationFinished()
		{
			return ( END_X <= current_x );
		}
	}
}

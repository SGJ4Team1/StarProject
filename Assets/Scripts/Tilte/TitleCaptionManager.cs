using UnityEngine;
using System.Collections;

public class TitleCaptionManager : MonoBehaviour {

	private Sprite[] _captions;
	private int _current = 0;
	private const int NUM_OF_CAPTIONS = 10;
	private const string RESOURCE_DIR = "Title/Caption/";

	// Use this for initialization
	void Start () {
	#if true
		_captions = new Sprite[NUM_OF_CAPTIONS];
		for(int index = 1;index <= NUM_OF_CAPTIONS; ++index ) {
			string sprite = RESOURCE_DIR + index.ToString();
			_captions[index-1] = Resources.Load<Sprite>(sprite);
			Debug.Assert( _captions[index-1] );
		}
	#else
		_captions = Resources.LoadAll<Sprite>(RESOURCE_DIR);
	#endif
		if( 0 == _captions.Length ) {
			Debug.Log( "[TitleCaptionManager] Failed to Load Caption Data\n");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// スプライト差し替えリクエスト
	public void ChangeRequest() {
		_current++;
		if( _current <= 0 || _captions.Length < _current ) {
			Debug.Assert( false );
			_current = _captions.Length;
		}		
		gameObject.GetComponent<SpriteRenderer>().sprite = _captions[_current];
	}
}

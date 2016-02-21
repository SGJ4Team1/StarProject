using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

// private const :
	
    private bool[] changeTable =
    {
        true,
		true,
		false,
		false,
		true,
		true,
		true,
		false,
        true,
		false,
		false,
    };
    private GameObject caption;
	
// private :
	private int _step = 0;

	// Use this for initialization
	void Start () 
	{
		Debug.Log( "Title Part Start" );
		caption = (GameObject)Resources.Load ("Title/Caption");
    }
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetMouseButtonDown(0) )
		{
			if( changeTable.Length <= _step ) return;

			switch( _step )
			{
			case 0:
				{ 
					// タイトル画面からあらすじ
					TitlePartAnimation script = GetComponent<TitlePartAnimation>();
					script.ChangeRequest();
					caption = Instantiate( caption );
				}
				break;
            case 10:
                {
                    // Scene Change
                    Debug.Log("Title Part Finish");
                }
                break;
			default:
				{
                    Debug.Log("Title Part Update");
					if( caption )
					{
						TitlePartAnimation script = caption.GetComponent<TitlePartAnimation>();
						script.ChangeRequest();
					}
					if (changeTable[_step])
					{
						TitlePartAnimation script = GetComponent<TitlePartAnimation>();
						script.ChangeRequest();
					}
				}
				break;
			}
            _step++;
		}
	}
}

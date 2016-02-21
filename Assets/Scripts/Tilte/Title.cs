using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    public GameObject caption;
    public GameObject logo;
    public GameObject button;

// private const :
	
    private bool[] changeTable =
    {
        true,
		true,
		false,
		false,
		true,
		true,
		false,
        true,
        true,
		false,
		false,
    };
    
	
// private :
	private int _step = 0;

	// Use this for initialization
	void Start () 
	{
		Debug.Log( "Title Part Start" );
        // タイトル画面用instance生成
		logo = Instantiate(logo);
        button = Instantiate(button);
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
                    // caption生成
					caption = Instantiate( caption );
                    // タイトル画面素材破棄
                    Destroy(logo);
                    Destroy(button);
				}
				break;
            case 10:
                {
                    // Scene Change
                    Debug.Log("Title Part Finish");
                    // caption破棄
                    Destroy(caption);
                    // 音停止
                    GameObject obj = GameObject.Find("Sound");
                    if (obj)
                    {
                        TitleSoundManager soundMgr = obj.GetComponent<TitleSoundManager>();
                        soundMgr.StopAll();
                    }
                    // GameMainへ飛ぶ
                    SceneManager.LoadScene("GameMain");
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

                        // ほんとはシングルトンすべきだろうけど…
                        GameObject obj = GameObject.Find("Sound");
                        if (obj)
                        {
                            TitleSoundManager soundMgr = obj.GetComponent<TitleSoundManager>();
                            soundMgr.PlaySe(0, 0.9f);
                        }
					}
				}
				break;
			}
            _step++;
		}
	}
}

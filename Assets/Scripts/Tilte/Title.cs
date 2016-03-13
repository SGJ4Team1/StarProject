using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour {

    public GameObject logo;
    public GameObject button;
	public GameObject fade;
	public GameObject intro2;
	public GameObject caption;

// private :
	

	// Find用object名
	private const string OBJECT_FADE = "Fade";

	// action定義
	enum eELEMENTS : int
	{
		eELEM_FADE_IN		,
		eELEM_FADE_OUT		,
		eELEM_BG_CHANGE		,
		eELEM_CAP_IN		,
		eELEM_CAP_OUT		,
		eELEM_TITLE_OUT		,
		eELEM_CHANGE_SCENE	,

		eELEM_MAX			,
	};
	System.Action[] phase = new System.Action[(int)eELEMENTS.eELEM_MAX];
	
	// actionシーケンス
    private eELEMENTS[] changeTable =
    {
		eELEMENTS.eELEM_FADE_IN,	// 暗転
        eELEMENTS.eELEM_TITLE_OUT,	// TitleBgとbutton out
		eELEMENTS.eELEM_BG_CHANGE,	// Intro1へ差し替え
		eELEMENTS.eELEM_FADE_OUT,	// 暗転明け
		eELEMENTS.eELEM_CAP_IN,		// 1「ある日～」
		eELEMENTS.eELEM_CAP_OUT,
		eELEMENTS.eELEM_BG_CHANGE,	// Intro1と2のFadeでたかしくんIn
		eELEMENTS.eELEM_CAP_IN,		// 2「おばあちゃん～」
		eELEMENTS.eELEM_CAP_OUT,
		eELEMENTS.eELEM_CAP_IN,		// 3「すると～」
		eELEMENTS.eELEM_CAP_OUT,
		eELEMENTS.eELEM_CAP_IN,		// 4「むかしは～」
		eELEMENTS.eELEM_CAP_OUT,
		eELEMENTS.eELEM_BG_CHANGE,	// Intro3へパ替え
		eELEMENTS.eELEM_CAP_IN,		// 5「ホシって～」
		eELEMENTS.eELEM_CAP_OUT,
		eELEMENTS.eELEM_BG_CHANGE,	// BG Fade 3to4
		eELEMENTS.eELEM_CAP_IN,		// 6「お空で～」
		eELEMENTS.eELEM_CAP_OUT,	
		eELEMENTS.eELEM_CAP_IN,		// 7「へぇ！～」
		eELEMENTS.eELEM_CAP_OUT,	
		eELEMENTS.eELEM_BG_CHANGE,	// BG 4to5
		eELEMENTS.eELEM_CAP_IN,		// 8「そうねぇ～」
		eELEMENTS.eELEM_CAP_OUT,	// 
		eELEMENTS.eELEM_BG_CHANGE,	// BG 5to6
		eELEMENTS.eELEM_CAP_IN,		// 9「わかった～」
		eELEMENTS.eELEM_CAP_OUT,	
		eELEMENTS.eELEM_CAP_IN,		// 10「こうして～」
		eELEMENTS.eELEM_FADE_IN,	// 文字ごと暗転
		eELEMENTS.eELEM_CHANGE_SCENE,
    };
	private int _current_phase = -1;	// Action進捗
    
	private bool _idle = true;	// シーケンスアクションを実行中かどうか
	private int _step = 0;		// シーケンス内ステップ	

	// Use this for initialization
	void Start () 
	{
		PrintDebug( "Title Part Start" );
        // タイトル画面用instance生成
		logo = Instantiate(logo);
        button = Instantiate(button);
		fade = Instantiate(fade);

		// action phase登録
		phase[(int)eELEMENTS.eELEM_FADE_IN] = this.PhaseFadeIn;
		phase[(int)eELEMENTS.eELEM_FADE_OUT] = this.PhaseFadeOut;
		phase[(int)eELEMENTS.eELEM_BG_CHANGE] = this.PhaseBgChange;
		phase[(int)eELEMENTS.eELEM_CAP_IN] = this.PhaseCaptionIn;
		phase[(int)eELEMENTS.eELEM_CAP_OUT] = this.PhaseCaptionOut;
		phase[(int)eELEMENTS.eELEM_TITLE_OUT] = this.PhaseTitleOut;
		phase[(int)eELEMENTS.eELEM_CHANGE_SCENE] = this.PhaseChangeScene;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if( !_idle ) { 
			if( _current_phase < 0 || changeTable.Length <= _current_phase ) {
				// 値が不正。Titleを抜ける。
				Debug.Assert( false );
				_current_phase = changeTable.Length - 1;
			}
			phase[(int)changeTable[_current_phase]]();
			if( !_idle ) return;	// action修了時は入力checkへ進む
		}

		if( Input.GetMouseButtonDown(0) ) {		
			StartAction();
		}
	}

	// FadeIn
	void PhaseFadeIn()
	{
		if( !fade ) {
			EndAction();
			return;
		}

		switch (_step)
		{
		case 0:
			PrintDebug("PhaseFadeIn");
			fade.GetComponent<FadeManager>().FadeIn();
			_step++;
			break;
		case 1:
			if( fade.GetComponent<FadeManager>().CheckFadeFinish() ) {
				EndAction();
				StartAction();		// 次を実行
			}
			break;
		default:
			Debug.Assert( false );	// 設計ミスっぽい
			EndAction();
			break;
		}
	}

	// FadeOut
	void PhaseFadeOut()
	{
		if( !fade ) {
			EndAction();
			return;
		}

		switch (_step)
		{
		case 0:
			PrintDebug("PhaseFadeOut");
			fade.GetComponent<FadeManager>().FadeOut();
			_step++;
			break;
		case 1:
			if( fade.GetComponent<FadeManager>().CheckFadeFinish() ) {
				EndAction();
				StartAction();	// つぎへ
			}
			break;
		default:
			Debug.Assert( false );	// 設計ミスっぽい
			EndAction();
			break;
		}
	}

	void PhaseBgChange()
	{
		switch (_step)
		{
		case 0:
			PrintDebug("PhaseBgChange");
			this.GetComponent<TitlePartAnimation>().ChangeRequest();
			if( intro2 ) {
				intro2.GetComponent<TitlePartAnimation>().ChangeRequest();
			}
			GameObject obj = GameObject.Find( "BGMMane" );
			if( obj ) {
				TitleSoundManager soundMgr = obj.GetComponent<TitleSoundManager>();
				soundMgr.PlaySe(0, 0.9f);
			}
			++_step;
			break;
		case 1:
			if( false != this.GetComponent<TitlePartAnimation>().CheckAnimationFinished()) {
				EndAction();
				StartAction();
			}
			else if( intro2 && false != intro2.GetComponent<TitlePartAnimation>().CheckAnimationFinished()) {
				EndAction();
				StartAction();
			}
			break;
		default :
			Debug.Assert( false );	// なんかミスしているっぽい
			EndAction();
			break;
		}
	}

	void PhaseCaptionIn()
	{
		if( !caption ) {
			EndAction();
			return;
		}

		switch (_step)
		{
		case 0:
			PrintDebug("PhaseCaptionIn");
			caption.GetComponent<FadeManager>().FadeIn();
			_step++;
			break;
		case 1:
			if( caption.GetComponent<FadeManager>().CheckFadeFinish() ) {
				EndAction();
			}
			break;
		default:
			Debug.Assert( false );	// 設計ミスっぽい
			EndAction();
			break;
		}
	}

	void PhaseCaptionOut()
	{
		if( !caption ) {
			EndAction();
			return;
		}

		switch (_step)
		{
		case 0:
			PrintDebug("PhaseCaptionOut");
			caption.GetComponent<FadeManager>().FadeOut();
			_step++;
			break;
		case 1:
			if( caption.GetComponent<FadeManager>().CheckFadeFinish() ) {
				// この時点で次の画像に差し替えておく
				caption.GetComponent<TitleCaptionManager>().ChangeRequest();	
				// 念のためもう一回
				_step++;
			}
			break;
		case 2:
			EndAction();
			StartAction();
			break;
		default:
			Debug.Assert( false );	// 設計ミスっぽい
			EndAction();
			break;
		}
	}

	void PhaseTitleOut()
	{ 
		PrintDebug("PhaseTitleOut");

        // タイトル画面用instnce破棄
		Destroy(logo);
        Destroy(button);

		// 終わり、次を実行
		EndAction();
		StartAction();
	}

	void PhaseChangeScene()
	{
		PrintDebug("PhaseTitleOut");

		// GameMainへ！
		SceneManager.LoadScene( "GameMain" );
	}

	void StartAction()
	{
		_current_phase++;
		if( _current_phase < 0 || changeTable.Length <= _current_phase ) {
			// 設計ミスっぽい
			Debug.Assert( false );
			_current_phase = changeTable.Length - 1;
		}
		_idle = false;
		phase[(int)changeTable[_current_phase]]();
	}

	void EndAction()
	{
		_idle = true;
		_step = 0;
	}

	void PrintDebug( string text )
	{
		if( false ) {
			Debug.Log( text );
		}
	}
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    delegate void SendFunc <T>(T obj) where T : IEventSystemHandler;

	// Use this for initialization
	void Start ()
    {
        GameStart();
	}

    public void GameStart()
    {
        Send<GameStartHandlar>((obj) => {obj.OnGameStart(); });
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void GameOver()
    {
        Send<GameOverHandlar> ((obj) => {obj.OnGameOver();  });
    }

    public void Clear()
    {
        Send<GameClearHandlar>((obj) => {obj.OnGameClear(); });
    }

    void Send <T>(SendFunc<T> sendFunc) where T : IEventSystemHandler
    {
        //GameManagerオブジェクトにあるスクリプトにメッセージをSend
        ExecuteEvents.Execute<T>(
            gameObject,
            null,
            (obj, baseEvent) => { sendFunc(obj); }
        );
    }
}

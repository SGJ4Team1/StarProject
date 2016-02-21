using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(GameManager), typeof(StageReader))]
public class GameSceneChanger : MonoBehaviour, GameClearHandlar, GameOverHandlar
{
    [SerializeField]
    string clearName;

    [SerializeField]
    string endingSceneName;

    [SerializeField]
    string gameOverSceneName;

    [SerializeField]
    int endStage;

    [SerializeField]
    StageReader reader;

	// Use this for initialization
	void Start ()
    {
	    reader = GetComponent<StageReader>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnGameClear()
    {
        if(reader.Stage == endStage)
        {
            SceneManager.LoadScene(endingSceneName);
        }

        SceneManager.LoadScene(clearName);
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene(gameOverSceneName, LoadSceneMode.Additive);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameManager), typeof(StageReader))]
public class GameSceneChanger : MonoBehaviour, GameClearHandlar
{
    [SerializeField]
    string sceneName;

    [SerializeField]
    string endingSceneName;

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

        SceneManager.LoadScene(sceneName);
    }
}

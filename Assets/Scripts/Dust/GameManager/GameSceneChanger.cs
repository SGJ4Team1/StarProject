using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameSceneChanger : MonoBehaviour, GameClearHandlar
{
    [SerializeField]
    string sceneName;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnGameClear()
    {
        SceneManager.LoadScene(sceneName);
    }
}

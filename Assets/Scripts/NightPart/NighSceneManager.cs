using UnityEngine;
using System.Collections;

public class NighSceneManager : MonoBehaviour {

    [Header("シーン先名")]
    public string SceneName;

    public void SceneButton()
    {
        Application.LoadLevel(SceneName);
    }
}

﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NighScenController : MonoBehaviour
{

    [Header("シーン先名")]
    public string SceneName;

    public void SceneButton()
    {
        SceneManager.LoadScene(SceneName);
        //Application.LoadLevel(SceneName);
    }
}

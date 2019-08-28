using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondSceneNextButton : ForwardButton
{
    private const string sceneName = "Scene4";

    protected override void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxSceneForwardButton : ForwardButton
{
    private const string sceneName = "Scene5";

    protected override void LoadNextScene()
    {
        CarScript.isSuccessful = true;

        SceneManager.LoadScene(sceneName);
    }
}

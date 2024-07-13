using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitch : MonoBehaviour
{
public void SwitchScene(string sceneName)
{
    SceneManager.LoadScene(sceneName);
}

public void quitgame()
{
    Application.Quit();
}

}
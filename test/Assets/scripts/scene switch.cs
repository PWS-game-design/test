using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitch : MonoBehaviour
{
void Awake()
{

}
public void SwitchScene(string sceneName)
{
    SceneManager.LoadScene(sceneName);
    MenuManager.instance.ClearList();
}

public void quitgame()
{
    Debug.Log("quit");
    Application.Quit();
}

}
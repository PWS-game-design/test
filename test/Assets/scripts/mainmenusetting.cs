using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenusetting : MonoBehaviour
{
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {

    }



    public void MainSettings()
    {
        canvas.SetActive(false);
        settings.instance.Settings.SetActive(true);
        MenuManager.instance.menus.Add(canvas);
    }

    public void PlayButton()
    {
        MainManager.Instance.Changepause(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
public class MainManager : MonoBehaviour
{

    public Action <bool> onPauseChange;
    public bool abletopause {get; private set;}
    public static MainManager Instance;
    public string LastScene;
    public GameObject adminB;
    public string currentsong;


    void Awake()
    {
        LastScene = "SampleScene";
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Changepause(false);
        onPauseChange += PlayerState;
        currentsong = "Theme";
    }






    public void Changepause(bool newstate)
    {
        abletopause = newstate;
        onPauseChange?.Invoke(abletopause);

    }

    public void PlayerState(bool pausstate)
    {

        if(PlayerManager.Instance == null)
        {
            return;
        }
    
        if(pausstate)
        {
            PlayerManager.Instance.Player.SetActive(true);

        }
        else
        {
            PlayerManager.Instance.Player.SetActive(false);

        }
    }

}

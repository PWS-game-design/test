using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
public class MainManager : MonoBehaviour
{

    public Action <bool> onPauseChange;
    public bool abletopause {get; private set;}
    public static MainManager Instance;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Changepause(false);
        onPauseChange += PlayerState;
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

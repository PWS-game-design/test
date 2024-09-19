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
        changepause(false);
        onPauseChange += PlayerState;
    }






    public void changepause(bool newstate)
    {
        abletopause = newstate;
        onPauseChange?.Invoke(abletopause);

    }

    public void PlayerState(bool pausstate)
    {
        if(Playermovement.Instance == null)
        {
            return;
        }
    
        if(pausstate)
        {
            Playermovement.Instance.Player.SetActive(true);
        }
        else
        {
            Playermovement.Instance.Player.SetActive(false);
        }
    }
    private void OnDisable() 
    {
        onPauseChange -= PlayerState;
    }
}

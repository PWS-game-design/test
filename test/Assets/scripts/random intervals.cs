using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomintervals : MonoBehaviour
{
    public float timer;
    public float wait;
    public float muziek;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(100, 120);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            muziek = Random.Range(1, 2);
            AudioManager.instance.Pause(MainManager.Instance.currentsong);
            if (muziek == 1)
            {
                AudioManager.instance.Play("something");
                wait = 73.848f;
            }
            if (muziek == 2)
            {
                AudioManager.instance.Play("something 2");
                wait = 30.772f;
            }
            timer = Random.Range(120, 180);
        }
        
        if(wait <= 0)
        {
            timer -= Time.deltaTime;
        }
        
        if(wait <= 0)
        {
            AudioManager.instance.UnPause(MainManager.Instance.currentsong);
        }
        
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }

    }

}

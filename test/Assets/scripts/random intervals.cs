using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomintervals : MonoBehaviour
{
    public float timer;
    public float wait;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(5, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {

            AudioManager.instance.Pause(MainManager.Instance.currentsong);
            AudioManager.instance.Play("something");
            wait = 73.848f;            
            timer = Random.Range(120, 180);
        }
        
        if(wait <= 0)
        {
            timer -= Time.deltaTime;
        }
        
        if(wait < 0)
        {
            AudioManager.instance.UnPause(MainManager.Instance.currentsong);
        }
        
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }

    }

}

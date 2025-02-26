using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomintervals : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer <= 0)
        {
            //AudioManager.instance.Stop(MainManager.Instance.currentsong);
            AudioManager.instance.Pause();
            AudioManager.instance.Play("something");
            timer = Random.Range(20, 300);
            Wait();
            //AudioManager.instance.Play(MainManager.Instance.currentsong);
        }
        timer -= Time.deltaTime;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(10);
    }
}

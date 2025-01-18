using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class hinttime : MonoBehaviour
{
    public float starttime;
    public GameObject hintposition;
    public GameObject text;
    float elapsedtime;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.rb.transform.position.x > hintposition.transform.position.x)
        {
            starttime += Time.fixedDeltaTime;
        }
        else
        {
            starttime = 0;
        }
        //elapsedtime = Time.realtimeSinceStartup - starttime;
        if (starttime > 10)
        {
            text.SetActive(true);
        }
    }
}

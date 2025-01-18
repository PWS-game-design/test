using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class hinttime : MonoBehaviour
{
    float starttime;
    public GameObject hintposition;
    public GameObject text;
    public int wichcondition;
    // 1 = rechts van
    // 2 = links van
    // 3 = onder
    // 4 is boven

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.rb.transform.position.x > hintposition.transform.position.x && wichcondition == 1 || PlayerManager.Instance.rb.transform.position.x < hintposition.transform.position.x && wichcondition == 2 || PlayerManager.Instance.rb.transform.position.y < hintposition.transform.position.y && wichcondition == 3 || PlayerManager.Instance.rb.transform.position.y > hintposition.transform.position.y && wichcondition == 4)
        {
            starttime += Time.deltaTime;
        }
        else
        {
            starttime = 0;
        }

        if (starttime > 10)
        {
            text.SetActive(true);
        }
    }
}

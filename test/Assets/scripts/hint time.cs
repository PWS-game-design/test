using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hinttime : MonoBehaviour
{
    float starttime;
    public GameObject hintposition;
    public GameObject text;
    public int wichcondition;
    public float alltime;
    int totalcount = 0;
    // 1 = rechts van
    // 2 = links van
    // 3 = onder
    // 4 = boven
    // 5 = onder en rechts van

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        PlayerManager.Instance.onDeath += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.rb.transform.position.x > hintposition.transform.position.x && wichcondition == 1 ||
        PlayerManager.Instance.rb.transform.position.x < hintposition.transform.position.x && wichcondition == 2 ||
        PlayerManager.Instance.rb.transform.position.y < hintposition.transform.position.y && wichcondition == 3 ||
        PlayerManager.Instance.rb.transform.position.y > hintposition.transform.position.y && wichcondition == 4 ||
        PlayerManager.Instance.rb.transform.position.y < hintposition.transform.position.y && PlayerManager.Instance.rb.transform.position.x > hintposition.transform.position.x && wichcondition == 5)
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
        alltime += Time.deltaTime;

        if (alltime > 50 && totalcount == 4 || alltime > 100)
        {
            text.SetActive(true);
        }
    }
    private void OnDeath()
    {
        totalcount += 1;
    }

}

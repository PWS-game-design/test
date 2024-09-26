using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class deathcount : MonoBehaviour

{
    int count = 0;


    public TextMeshProUGUI ValueText;
    private Rigidbody2D rb;
    public GameObject ParamL;
    public GameObject ParamR;


    // Start is called before the first frame update
    void Start()
    {
        rb = PlayerManager.Instance.rb;
        PlayerManager.Instance.onDeath += OnDeath;
    }



    private void OnDeath()
    {

        if(PlayerManager.Instance.rb.transform.position.x < ParamR.transform.position.x && PlayerManager.Instance.rb.transform.position.x > ParamL.transform.position.x)
        {
            count = count + 1;
            ValueText.text = count.ToString();
        }
        if(count == 5)
        {

            AudioManager.instance.Play("CollinTheme");
            AudioManager.instance.Stop("Theme");
            SceneManager.LoadScene("Frosty-Quest");

        }
        
    }
    private void OnDisable() 
    {
        PlayerManager.Instance.onDeath -= OnDeath;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ParamL.transform.position, 1f);
        Gizmos.DrawWireSphere(ParamR.transform.position, 1f);
    }
}
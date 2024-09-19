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


    // Start is called before the first frame update
    void Start()
    {
        rb = Playermovement.Instance.rb;
        Playermovement.Instance.onDeath += OnDeath;
    }

    // Update is called once per frame

    private void OnDeath()
    {


            count = count + 1;
            ValueText.text = count.ToString();

        if(count == 5)
        {

            AudioManager.instance.Play("CollinTheme");
            AudioManager.instance.Stop("Theme");
            SceneManager.LoadScene("Frosty-Quest");

        }
    }
    private void OnDisable() 
    {
        Playermovement.Instance.onDeath -= OnDeath;
    }
}
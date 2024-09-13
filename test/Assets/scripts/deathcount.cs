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
[SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Playermovement.Instance.transform.position.y < -20f)
        {
            count = count + 1;
            ValueText.text = count.ToString();
        }  
        if(count == 1)
        {

            AudioManager.instance.Play("CollinTheme");
            AudioManager.instance.Stop("Theme");
            SceneManager.LoadScene("Frosty-Quest");

        }
    }
}
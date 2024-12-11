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
    public string NextScene;
    public string StopMusic;
    public string StartMusic;


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
        if(count == 1)
        {

            AudioManager.instance.Play(StartMusic);
            AudioManager.instance.Stop(StopMusic);
            MainManager.Instance.LastScene = NextScene;

            if (MainManager.Instance.LastScene == "first-art")
            {
                PlayerManager.Instance.playerrb.enabled = true;
                PlayerManager.Instance.Playerrb.enabled = true;
                PlayerManager.Instance.building.SetActive(false);

            }
            SceneManager.LoadScene(NextScene);            
             
        }
        
    }
    private void OnDisable() 
    {
        PlayerManager.Instance.onDeath -= OnDeath;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ParamL.transform.position, .25f);
        Gizmos.DrawWireSphere(ParamR.transform.position, .25f);
    }
}
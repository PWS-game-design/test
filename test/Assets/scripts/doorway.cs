using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorway : MonoBehaviour
{
    //public static doorway Instance;
    public GameObject ParamL;
    public GameObject ParamR;
    public string Nextscene;
    public string StopMusic;
    public string StartMusic;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Doorway();
    }

    private void Doorway()
    {
        if (PlayerManager.Instance.rb.transform.position.x > ParamL.transform.position.x && PlayerManager.Instance.rb.transform.position.x < ParamR.transform.position.x && Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.Play(StartMusic);
            MainManager.Instance.currentsong = StartMusic;
            AudioManager.instance.Stop(StopMusic);
            MainManager.Instance.LastScene = Nextscene;
            SceneManager.LoadScene(Nextscene);

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ParamL.transform.position, 0.2f);
        Gizmos.DrawWireSphere(ParamR.transform.position, 0.2f);
    }
}

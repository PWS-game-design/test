using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    static bool settings;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        settings = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && settings == false)
        {
            if(isPaused)
            {
                Debug.Log("resume");
                ResumeGame();
            }
            else
            {
                Debug.Log("Pause");
                PauseGame();
            }
                
        }
    }


    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
        public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }



    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void settingsmenu()
    {
        if(settings == true)
        {
            Debug.Log("false");
            settings = false;
        }
        else
        {
            Debug.Log("true");
            settings = true;
        }
    }
}
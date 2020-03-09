using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour

{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Audio
    public AudioSource Background;



    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        

        // Referencia audio de background
        Background = Background.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Resume()
    {
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pausa()
    {
        pauseMenuUI.SetActive(true);
        //Background.volum;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

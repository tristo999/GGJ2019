using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject fadeCanvas;
    public CutScenes fader;
    public bool pauseActive;
    public bool restartingGame;
    public float cooldown = 2f;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        pauseActive = false;
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");
        restartingGame = false;
        fader = this.gameObject.GetComponent<CutScenes>();
        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                pauseMenu.SetActive(false);
            } else
            {
                pauseMenu.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (restartingGame)
        {
            if (fader.fadeImage.color.a >= 1)
            {
                timer += Time.deltaTime;
                if (timer >= cooldown )
                {
                    fader.targetText = 0;
                    fader.fadeInImage = -1;
                    fader.fadeIn = 1;
                    if (fader.currentText.color.a <= 0)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }

        }
    }

    public void killPlayer()
    {
        fader.play2();
        restartingGame = true;
    }
}

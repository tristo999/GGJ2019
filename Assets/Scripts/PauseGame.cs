using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pauseActive;
    // Start is called before the first frame update
    void Start()
    {
        pauseActive = false;
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
    }
}

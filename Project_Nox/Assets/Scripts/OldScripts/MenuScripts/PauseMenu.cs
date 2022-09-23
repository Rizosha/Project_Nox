using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    private void Start() { Resume(); }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (GameIsPaused) { Resume(); }
            else { Pause(); }
        }
        if (GameIsPaused) { Cursor.visible = true; Cursor.lockState = CursorLockMode.None; }
        else { Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() { SceneManager.LoadScene("MainMenu"); }
    public void Quit() { Application.Quit(); }
    public void Restart() { SceneManager.LoadScene("Level_01"); }
}

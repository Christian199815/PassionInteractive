using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    private bool isFullscreen = false;

    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void SettingsButton()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
    }

    public void BackButton()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
    }
}

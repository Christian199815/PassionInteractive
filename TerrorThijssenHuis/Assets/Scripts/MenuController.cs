using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

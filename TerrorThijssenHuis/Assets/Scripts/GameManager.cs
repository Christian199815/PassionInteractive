using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject occlusionSquares;
    public Image[] livesImages;
    [SerializeField] private GameObject deathBackground;
    [SerializeField] private GameObject deathUI;
    
    void Start()
    {
        for (int i = 0; i < occlusionSquares.transform.childCount; i++)
        {
            Transform child = occlusionSquares.transform.GetChild(i);
            child.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        }
    }

    public void LivesUI(int life)
    {
        int minLife = Mathf.Max(0, life);

        if (minLife >= 0)
        {
            for (int i = minLife; i <= 4; i++)
            {
                if (i < livesImages.Length)
                {
                    Destroy(livesImages[i]);
                }
            }
        }
    }

    public void Death()
    {
        Time.timeScale = 0;
        deathBackground.SetActive(true);
        deathUI.SetActive(true);
    }

    public void Respawn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

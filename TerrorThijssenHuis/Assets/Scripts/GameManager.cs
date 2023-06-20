using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Destroy(livesImages[life]);
    }

    public void Death()
    {
        Time.timeScale = 0;
        deathBackground.SetActive(true);
        deathUI.SetActive(true);
    }
}
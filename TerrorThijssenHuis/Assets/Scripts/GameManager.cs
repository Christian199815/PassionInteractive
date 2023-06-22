using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject occlusionSquares;
    public GameObject[] livesObjects;
    [SerializeField] private GameObject deathBackground;
    [SerializeField] private GameObject deathUI;
    public Color hiddenColor;
    [SerializeField] public Player player;

    [SerializeField] private Transform LiftArea1;
    [SerializeField] private Transform LiftEnd;
    
    void Start()
    {
        // for (int i = 0; i < occlusionSquares.transform.childCount; i++)
        // {
        //     Transform child = occlusionSquares.transform.GetChild(i);
        //     child.GetComponent<SpriteRenderer>().color = hiddenColor;
        // }

        
    }



    public void StartExploring()
    {
        player.transform.position = new Vector3(6, 46, transform.position.z);
    }

    public void EndExploring()
    {
        player.transform.position = new Vector3(-12, -46 ,transform.position.z);
    }

    // void DisplayLivesUI()
    // {
    //     switch(player.lives)
    //     {
    //         case 5:
    //             livesObjects[4].SetActive(true);
    //             livesObjects[3].SetActive(true);
    //             livesObjects[2].SetActive(true);
    //             livesObjects[1].SetActive(true);
    //             livesObjects[0].SetActive(true);
    //             break;
    //         case 4:
    //             livesObjects[4].SetActive(false);
    //             livesObjects[3].SetActive(true);
    //             livesObjects[2].SetActive(true);
    //             livesObjects[1].SetActive(true);
    //             livesObjects[0].SetActive(true);
    //             break;
    //         case 3:
    //             livesObjects[3].SetActive(false);
    //             livesObjects[2].SetActive(true);
    //             livesObjects[1].SetActive(true);
    //             livesObjects[0].SetActive(true);
    //             break;
    //         case 2:
    //             livesObjects[2].SetActive(false);
    //             livesObjects[1].SetActive(true);
    //             livesObjects[0].SetActive(true);
    //             break;
    //         case 1:
    //             livesObjects[1].SetActive(false);
    //             livesObjects[0].SetActive(true);
    //             break;
    //     }
    
    // }


    // private void Update()
    // {
    //     DisplayLivesUI();
    // }

    public void AddLifeUI(int life)
    {
        if (life >= 0 && life < livesObjects.Length)
        {
            livesObjects[life].gameObject.SetActive(true);
        }
    }

    public void RemoveLifeUI(int life)
    {
        int minLife = Mathf.Max(0, life);

        if (minLife >= 0)
        {
            for (int i = minLife; i <= 4; i++)
            {
                if (i < livesObjects.Length)
                {
                    livesObjects[i].gameObject.SetActive(false);
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

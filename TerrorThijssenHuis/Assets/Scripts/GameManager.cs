using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject occlusionSquares;
    
    void Start()
    {
        for (int i = 0; i < occlusionSquares.transform.childCount; i++)
        {
            Transform child = occlusionSquares.transform.GetChild(i);
            child.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhideLevel : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            sr.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            sr.color = new Color(0, 0, 0, 255);
        }
    }

}

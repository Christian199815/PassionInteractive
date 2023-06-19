using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhideLevel : MonoBehaviour
{
    public SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.transform.CompareTag("Player"))
    //    {
    //        SR.color = new Color(0, 0, 0, 0);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        SR.color = new Color(0, 0, 0, 255);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
       {
           SR.color = new Color(0, 0, 0, 0);
       }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
       {
           SR.color = new Color(0, 0, 0, 255);
       }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhideLevel : MonoBehaviour
{
    private SpriteRenderer SR;
    public DialogueUI DUI;
    private CameraFollow CF;
    public int locationIndex;

    public Color hiddenColor;

    private bool UITriggered;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        CF = FindObjectOfType<Camera>().GetComponent<CameraFollow>();
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //         if (!UITriggered) { DUI.playRoomMessage(this.name); UITriggered = true; }
    //         CF.playerLocs[locationIndex] = true;
    //         SR.color = new Color(0, 0, 0, 0);
    //    }
    // }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.transform.CompareTag("Player"))
    //    {
    //         CF.playerLocs[locationIndex] = false;
    //         SR.color = hiddenColor;
    //    }
    // }
}

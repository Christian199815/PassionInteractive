using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public int noteNumber;
    public DialogueUI DUI;

    public int messageDisplaySeconds = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DUI.playMessage(noteNumber, messageDisplaySeconds);
            Destroy(this.gameObject);
        }
    }
}

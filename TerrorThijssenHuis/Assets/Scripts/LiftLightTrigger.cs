using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftLightTrigger : MonoBehaviour
{
    public GameObject playerLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.transform.CompareTag("Player"))
       {
            playerLight.SetActive(true);
       }
    }
}

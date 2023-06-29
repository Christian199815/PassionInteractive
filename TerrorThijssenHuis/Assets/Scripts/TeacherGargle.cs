using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherGargle : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(Random.Range(4.0f, 9.0f));
        audioSource.pitch = (Random.Range(0.6f, 1.15f));
        audioSource.Play();
        StartCoroutine(WaitForSound());
    }
}

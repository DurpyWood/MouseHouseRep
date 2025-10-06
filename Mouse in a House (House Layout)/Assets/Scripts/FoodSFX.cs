using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public AudioClip audioClip;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioClip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSorce;
    [SerializeField] private AudioClip wingsFlap, updateScore;

    private void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }
    public void PlaySound(string sound)
    {
        if (sound == "Wing Flap")
            audioSorce.PlayOneShot(wingsFlap);        
        if (sound == "Score Update")
            audioSorce.PlayOneShot(updateScore);
    }
}

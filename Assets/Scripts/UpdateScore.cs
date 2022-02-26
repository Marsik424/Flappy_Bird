using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    private AudioManager audioManager;
    private void Start() => audioManager = FindObjectOfType<AudioManager>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Score++;
            audioManager.PlaySound("Score Update");
        }
    }
}

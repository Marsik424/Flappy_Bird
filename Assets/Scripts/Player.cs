using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private int score = 0;
    [Header("Must be attached")] 
    [SerializeField] private TextMeshProUGUI _score;

    private Rigidbody2D _rigidbody2D;
    private AudioManager _audioManager;
    

    public int Score 
    {
        get => score;
        set
        {
            score = value;
            _score.text = value.ToString();
        } 
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            _rigidbody2D.velocity = Vector2.up * jumpForce;
            _audioManager.PlaySound("Wing Flap");
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Pipe"))
            GameManager.Instance.UpdateGameState(GameState.Lose);
    }

}

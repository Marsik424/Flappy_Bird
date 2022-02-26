using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static GameState State;

    public static GameManager Instance;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        DontDestroyOnLoad(Instance);
    }

    private void Start() => UpdateGameState(GameState.StartMenu);

    private void Update()
    {
        if (State == GameState.StartMenu && Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            UpdateGameState(GameState.Resume);
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        OnGameStateChanged?.Invoke(newState);
    }
    public void CheckPauseButton()
    {
        if (Time.timeScale > 0)
            UpdateGameState(GameState.Pause);
        else
            UpdateGameState(GameState.Resume);
    }
}
public enum GameState
{
    StartMenu,
    Lose,
    Resume,
    Pause,
    Settings
}
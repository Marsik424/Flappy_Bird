using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas PauseMenu;
    [SerializeField] private Canvas StartMenu;
    [SerializeField] private Canvas GameOverMenu;
    [SerializeField] private bool PauseState;
    [SerializeField] private bool StartState;
    [SerializeField] private bool GameOverState;

    private void Awake() => GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    private void OnDestroy() => GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;

    private void GameManager_OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.StartMenu:
                StartState = true;
                break;

            case GameState.Lose:
                GameOverState = true;
                break;

            case GameState.Pause:
                PauseState = true;
                break;

            default:
                PauseState = false;
                StartState = false;
                GameOverState = false;
                break;
        }
        Time.timeScale = PauseState || StartState || GameOverState ? 0 : 1;

        StartScene();
        PauseScene();
        GameOverScene();
    }
    private void StartScene() => StartMenu.gameObject.SetActive(StartState);
    private void PauseScene() => PauseMenu.gameObject.SetActive(PauseState);
    private void GameOverScene() => GameOverMenu.gameObject.SetActive(GameOverState);
}

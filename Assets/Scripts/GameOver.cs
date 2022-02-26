using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private Image goldMedal;
    [SerializeField] private Image silverMedal;
    [SerializeField] private Player player;

    private int bestScoreI;
   
    private void OnEnable()
    {
        animator.SetBool("Is Player dead", true);
        currentScore.text = player.Score.ToString();
        bestScoreI = player.Score;
        if (PlayerPrefs.GetInt("Best Score") < bestScoreI)
        {
            goldMedal.gameObject.SetActive(true);
            bestScore.text = bestScoreI.ToString();
            PlayerPrefs.SetInt("Best Score", bestScoreI);
        }
        else
        {
            bestScore.text = PlayerPrefs.GetInt("Best Score").ToString();
            silverMedal.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        animator.SetBool("Is restart button pressed", true);
        Time.timeScale = 1; 
        SceneManager.LoadScene(0);
    }
}

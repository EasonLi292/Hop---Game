using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject DeathPanel;
    public TextMeshProUGUI HighScoreUI;
    public TextMeshProUGUI ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void GameOver() {
        // Update Score on Death Panel
        ScoreManager SM = FindObjectOfType<ScoreManager>();
        ScoreUI.text = "Score: " + SM.GetScore();
        HighScoreUI.text = "HIGHSCORE: " + JumpInfo.Highscore;

        // Stop Player from Moving
        FindObjectOfType<FloatingController>().SetCanMove(false);

        // Stop Time and Open Panel
        DeathPanel.SetActive(true);
        Time.timeScale = 0.5f;
    }

    public void StartGame() {
        // Allow Player to Move
        FindObjectOfType<FloatingController>().SetCanMove(true);

        // Deactivate Death Panel and Start Game
        DeathPanel.SetActive(false);
        Time.timeScale = 1;
    }
}

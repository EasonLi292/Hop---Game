using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreUI;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreUI.text = "SCORE: " + score;
    }

    public void IncreaseScore(int addedScore) {
        score += addedScore;
        ScoreUI.text = "SCORE: " + score;

        // Update HighScore
        if (score > JumpInfo.Highscore) {
            JumpInfo.Highscore = score;
        }
    }

    public int GetScore() {
        return score;
    }
}

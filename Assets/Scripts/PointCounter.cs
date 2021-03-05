using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public Text pointScoreCounter;
    public Text livesCounter;
    private static int score = 0;
    private static int defaultScore = 0;
    private static int lives = 3;

    public void incrementScore() {
        score++;
    }
    public void resetScore() {
        score = defaultScore;
    }
    public void setDefaultScore() {
        defaultScore = score;
    }
    public int getLives() {
        return lives;
    }
    public void decrementLives() {
        lives--;
    }

    // Update is called once per frame
    void Update()
    {
        pointScoreCounter.text = "Score: " + score;
        livesCounter.text = "Lives: " + lives;
    }
}

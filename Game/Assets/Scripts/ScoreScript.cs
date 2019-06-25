using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public float highScore;

    void Start()
    {
        score = 0;
        SetToHighScore(score);
    }

    public float AddScore(float score)
    {
        score += this.score;
        return score;
    }
    public float SetToHighScore(float score)
    {
        if (score > highScore)
        {
            return this.score;
        }
        else
        {
            this.score = highScore;
            PlayerPrefs.SetFloat("highScore", highScore);
            return score;
        }
    }
}
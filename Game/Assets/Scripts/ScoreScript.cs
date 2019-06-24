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
    }

    public float AddScore(float score)
    {
        score += this.score;
        return score;
    }
    public float SetToHighScore(float highScore)
    {
        if (this.highScore > score)
        {
            return highScore;
        }
        else
        {
            this.highScore = score;
            return highScore;
        }
    }
}
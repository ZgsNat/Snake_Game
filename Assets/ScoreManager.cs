using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;
    public static ScoreManager instance;
    // Start is called before the first frame update
    int Score = 0;
    int HighScore = 0;

    public void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        ScoreText.text = "Score: " + Score.ToString();
        HighScoreText.text ="HighScore: " + HighScore.ToString();
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        Score += 10;
        ScoreText.text = "Score: " + Score.ToString();
    }
    public void UpdateHighScore()
    {
        if (HighScore < Score)
        PlayerPrefs.SetInt("HighScore", Score);
    }
    public void ResetPoint()
    {
        Score = 0;
    }

}

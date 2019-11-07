using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    static public Score S;

    public Text scoreText;
    public Text highScoreText;

    public bool ________________________;

    public int score;
    public int highScore;
    public string levelName;
    

    void Awake()
    {
        score = 0;
        if (PlayerPrefs.HasKey(levelName))
        {
            highScore = PlayerPrefs.GetInt(levelName);
        }
        else
        {
            PlayerPrefs.SetInt(levelName, score);
        }
    }

    void Update()
    {
        levelName = "LevelHighScore_" + MissionDemolition.S.level;
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt(levelName);
        if (score > PlayerPrefs.GetInt(levelName))
        {
            PlayerPrefs.SetInt(levelName, score);
            highScore = score;
            
        }

    }

}

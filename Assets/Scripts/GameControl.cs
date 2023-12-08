using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public int score=0,highScore;
    [SerializeField] Text scoreText;
    private void Start()
    {
        score= 0;
        SetScoreText("Score: " + score);
        highScore = Getint("highScore");
    }
    private void Update()
    {
        SetInt("highScore", highScore);
    }
    public void SetScoreText(string txt)
    {
        if (scoreText) scoreText.text = txt;
    }
    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}

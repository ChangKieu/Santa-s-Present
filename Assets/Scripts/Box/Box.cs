using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Box : MonoBehaviour
{   
    GameControl control;
    Health health;
    public int highscore;
    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            control.score++;
            if(control.score > control.highScore)
            {
                control.highScore = control.score;
            }
            Destroy(gameObject);
            control.SetScoreText("Score: " + control.score);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(health.healthCount<3) health.healthCount++;
            Destroy(gameObject);
        }
    }
}

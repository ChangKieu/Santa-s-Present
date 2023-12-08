using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] Image[] health;
    [SerializeField] GameObject panel;
    [SerializeField] Text score, hightscore;
    GameControl control;
    public int healthCount;
    private void Start()
    {
        healthCount = 3;
        panel.SetActive(false);
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
    }
    private void Update()
    {
        for (int i = 0; i < health.Length; i++)
        {
            if (i < healthCount)
            {
                health[i].enabled = true;
            }
            else health[i].enabled = false;
        }
        if(healthCount == 0)
        { 
            score.text = "Score: " + control.score;
            hightscore.text = "High Score: " + control.highScore;
            if(panel) panel.SetActive(true);
        }
    }
}

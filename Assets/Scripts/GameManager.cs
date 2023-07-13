using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager ins;
    public static GameManager Instance { get { return ins; } }

    public Text scoreTxt;
    public Player player;
    public GameObject playBtn;
    public GameObject gameOver;

    private int score;

    private void Awake()
    {
        if (ins != null && ins != this)
            Destroy(gameObject);

        ins = this;

        Application.targetFrameRate = 60;
        Pause();

        gameOver.SetActive(false);
    }

    public void Play()
    {
        score = 0;
        scoreTxt.text = score.ToString();

        playBtn.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipe = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipe.Length; i++)
        {
            Destroy(pipe[i].gameObject);
        }
    }

    public void Pause()
    {
        playBtn.SetActive(true);
        gameOver.SetActive(true);

        Time.timeScale = 0f;

        player.enabled = false;
    }

    public void GameOver()
    {    
        Pause();
    }
    public void InceaseScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
}

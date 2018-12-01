using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using MonotypeUnityTextPlugin;
using System;

public class ScoreText : MonoBehaviour
{

    public static MP3DTextComponent textTimer;
    public MP3DTextComponent text;

    private static int currentScore;

    void Start()
    {
        textTimer = text;
        currentScore = 0;

    }

    public static void SetScore(int score){
        currentScore = score;
        textTimer.Text = "Score: " + currentScore;
    }

    internal static void SetText(string v)
    {
        textTimer.Text = v;
    }

    public static void IncrementScore(int increment)
    {
        currentScore += increment;
        textTimer.Text = "Score: " + currentScore;
    }

    public static void GameOver()
    {
        textTimer.Text = "Game over";
    }

    public static void ResetScore()
    {
        currentScore = 0;
        textTimer.Text = "Score: " + currentScore;
    }


}
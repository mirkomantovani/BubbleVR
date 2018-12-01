using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using MonotypeUnityTextPlugin;
using System;

public class GameModeText : MonoBehaviour
{

    public static MP3DTextComponent staticText;
    public MP3DTextComponent text;


    void Start()
    {
        staticText = text;
    }

    internal static void SetText(string v)
    {
        staticText.Text = v;
    }


    public static void GameOver()
    {
        staticText.Text = "Game over";
    }

    public static void ResetText()
    {

        staticText.Text = "GameMode";
    }


}
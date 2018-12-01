using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    private static IGameMode game;

    private static AudioSource staticGameOver;
    public AudioSource gameOver;
    private static GameObject trainingBalls;
    public GameObject tBalls;
    public GameObject timer;
    public static GameObject staticTimer;
    public GameObject score;
    public static GameObject staticScore;
    public GameObject restartBall;
    public static GameObject staticRestartBall;

    public static bool IsGameOver = false;

    // Use this for initialization
    void Start () {
        staticGameOver = gameOver;
        staticTimer = timer;
        staticScore = score;
        staticRestartBall = restartBall;
        trainingBalls = tBalls;

	}

    public static void GameOver()
    {   
        if(!IsGameOver){
            IsGameOver = true;
            Debug.Log("Game over in Game Manager");
            RestartGame.DetachFloor();
            GameModeText.GameOver();
            staticGameOver.Play();
            //BallManager.ExplodeBalls();
            //BallManager.ExplodeBalls();
            //BallManager.ExplodeBalls();
        }
    }

    public static void SetTrainingBallsVisible(){
        trainingBalls.SetActive(true);
    }

    public static void StartGame(IGameMode g)
    {
        staticTimer.SetActive(true);
        staticScore.SetActive(true);
        game = g;
        //game = gameObject.AddComponent<game.GetType>();
        g.StartPlaying();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public static void AppearRestartBall(){
        staticRestartBall.SetActive(true);
    }

    internal static bool CanDie()
    {
        //Debug.Log("is game mode");
        //Debug.Log(game.GetType());
        return !(game is GodMode | game is Training);
    }
}

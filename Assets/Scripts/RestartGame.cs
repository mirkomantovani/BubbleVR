using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour {


    public GameObject baseFloor;
    public static GameObject staticbaseFloor;


    public static void DetachFloor()
    {

        staticbaseFloor.AddComponent<Rigidbody>();
    }

    public static void RestartScene()
    {
        BallManager.ResetBallList();
        GameManager.IsGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private static void ClearStuff()
    {
        //GameObject.Find("TrainingBalls").SetActive(false);
        //GameModeText.ResetText();
        //ScoreText.ResetScore();
        //GameObject.Find("Score").SetActive(false);
        //GameObject.Find("Time").SetActive(false);
    }

    // Use this for initialization
    void Start () {
        //player.transform.position = new Vector3(3f, 13f, 3f);
        staticbaseFloor = baseFloor;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

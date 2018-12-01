using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : BallSpawner, IGameMode
{

    
    public new void StartPlaying()
    {
        GameManager.SetTrainingBallsVisible();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

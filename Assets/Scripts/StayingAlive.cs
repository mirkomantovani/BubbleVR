using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayingAlive : BallSpawner, IGameMode
{
    private const int CANNON1 = 1;
    private const int CANNON2 = 2;
    private const int CANNON3 = 3;
    private const int CANNON4 = 4;

    private const string BALL0 = "Ball0";
    private const string BALL = "Ball";
    private const string BALL2 = "Ball2";

    public void StartPlaying()
    {
        StartRecursiveRandomBallGenerator(20);
        //SpawnBall(CANNON1, BALL2,2.0f);
        //SpawnBall(CANNON3, BALL, 5.0f);
        //SpawnBall(CANNON2, BALL0, 10.0f);

    }

    private 

    // Use this for initialization
    new void Start () {
        //calling super.start to initialize the BallSpawner since it's a monobehavior not attached to any object
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayingAlive : BallSpawner, IGameMode
{
    private const int CANNON1 = 1;
    private const int CANNON2 = 2;
    private const int CANNON3 = 3;
    private const int CANNON4 = 4;

    private const string SPECIAL0 = "Snowflake";
    private const string SPECIAL1 = "Bomb";
    private const string SPECIAL2 = "Shield";

    private const int SPECIALITEMSCOUNT = 3;

    private System.Random random = new System.Random();

    protected const int HARDER_LEVEL_TIME = 30;

    private const string BALL0 = "Ball0";
    private const string BALL = "Ball";
    private const string BALL2 = "Ball2";
     

    public void StartPlaying()
    {
        Debug.Log("Staying alive start playing");
        StartRecursiveRandomBallGenerator(15);
        StartRecursiveRandomSpecialItemGenerator(30);

        // To Cancel all Invoke calls
        //CancelInvoke();
        InvokeRepeating("HardenLevel", HARDER_LEVEL_TIME, HARDER_LEVEL_TIME);

    }

    protected void StartRecursiveRandomSpecialItemGenerator(int seconds){
        InvokeRepeating("SpawnRandomSpecialItem", seconds, seconds);
    }

    private void SpawnRandomSpecialItem(){
        int itemNumber = random.Next(0, SPECIALITEMSCOUNT);
        SpawnRandomSpecialItem(itemNumber);
    }

    private void SpawnRandomSpecialItem(int itemNumber)
    {
        string specialName = SPECIAL0;
        switch(itemNumber){
            case 0:
                specialName = SPECIAL0;
                break;
            case 1:
                specialName = SPECIAL1;
                break;
            case 2:
                specialName = SPECIAL2;
                break;

        }

        float x = (float)random.NextDouble() * 2 - 1f;
        float z = (float)random.NextDouble() * 2 - 1f;
        float y = 8f;
        GameObject specialItem = (GameObject)Instantiate(Resources.Load(specialName));
        Vector3 pos = new Vector3(x, y, z);
        specialItem.GetComponent<Rigidbody>().position = pos;
    }

    private void HardenLevel(){
        IncrementTimeRangeRandomSpawnMax(-1);
        IncrementTimeRangeRandomSpawnMin(-1);
    }

    // Use this for initialization
    new void Start () {
        //calling super.start to initialize the BallSpawner since it's a monobehavior not attached to any object
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

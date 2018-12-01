using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : StayingAlive, IGameMode
{

    public new void StartPlaying()
    {
        StartRecursiveRandomBallGenerator(10);
        StartRecursiveRandomSpecialItemGenerator(15);

        // To Cancel all Invoke calls
        //CancelInvoke();
        InvokeRepeating("HardenLevel", HARDER_LEVEL_TIME, HARDER_LEVEL_TIME);

    }


	
	// Update is called once per frame
	void Update () {
		
	}
}

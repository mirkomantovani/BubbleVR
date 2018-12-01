using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour {

    //Target height should be computed as SpeedYFromGround^2/2g or viceversa

    public static float TargetHeight0 = 5.1f;
    public static float SpeedYFromGround0 = 10.0f;
		  
    public static float TargetHeight = 3.2f;
    public static float SpeedYFromGround = 8.0f;
		  
    public static float TargetHeight2 = 2.5f;
    public static float SpeedYFromGround2 = 7.0f;

    public static float GetTargetHeight(string tag)
    {
        switch(tag){
            case "ball0":
                return TargetHeight0;
            case "ball":
                return TargetHeight;
            case "ball2":
                return TargetHeight2;
        }
        return 10;
    }

    public static float GetSpeedYFromGround(string tag)
    {
        switch (tag)
        {
            case "ball0":
                return SpeedYFromGround0;
            case "ball":
                return SpeedYFromGround;
            case "ball2":
                return SpeedYFromGround2;
        }
        return 10;
    }

    //get height of the ball that will be created with the popping of the passed ball
    internal static float GetPoppedBallTargetHeight(string tag)
    {
        switch (tag)
        {
            case "ball0":
                return TargetHeight;
            case "ball":
                return TargetHeight2;
            
        }
        return 10;
    }
}

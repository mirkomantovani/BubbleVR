using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour {

    //Target height should be computed as SpeedYFromGround^2/2g or viceversa

    public static float TargetHeight0 = 11.0f;
    public static float SpeedYFromGround0 = 10.0f;
		  
    public static float TargetHeight = 9.0f;
    public static float SpeedYFromGround = 8.0f;
		  
    public static float TargetHeight2 = 7.0f;
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
}

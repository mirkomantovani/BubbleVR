using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesBall : MonoBehaviour {

    public float TargetHeight = 10.0f;
    public float SpeedYFromGround = 10.0f;

    public float GetTargetHeight(){
        return TargetHeight;
    }

    public float GetSpeedYFromGround()
    {
        return SpeedYFromGround;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

    private float InitialForwardX;
    //private float InitialForwardY;
    private float InitialForwardZ;

    public void setX(float x){
        InitialForwardX = x;
    }

    public void setZ(float z){
        InitialForwardZ = z;
    }

    public float getX(){
        return InitialForwardX;
    }

    public float getZ()
    {
        return InitialForwardZ;
    }


}

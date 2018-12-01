using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UseFreeze : VRTK_InteractableObject
{
    public AudioSource sound;
    // Use this for initialization
    void Start()
    {

    }

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        use();
    }

    private void use()
    {
        //Debug.Log("object used");
        //ScoreText.SetScore(100);
        sound.Play();
        BallManager.StopBalls();
        Destroy(gameObject,1);
    }

}

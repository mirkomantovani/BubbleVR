using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UseBomb : VRTK_InteractableObject
{
    public AudioSource sound;

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        use();
    }

    private void use()
    {
        Destroy(gameObject,2);
        BallManager.ExplodeBalls();
        Invoke("CallExplode", 0.5f);
        Invoke("CallExplode", 1f);
        //cannot destroy object otherwise invokes wont work
        sound.Play();
    }

    private void CallExplode(){
        Debug.Log("callexplode in usebomb");
        BallManager.ExplodeBalls();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UseShield : VRTK_InteractableObject
{
    public AudioSource sound;
    public GameObject shieldMesh;
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
        ShieldManager.ActivateShield();
        Invoke("DeactivateShield", 30);
        sound.Play();
        shieldMesh.SetActive(false);
        Destroy(gameObject,31);
    }

    private void DeactivateShield(){
        ShieldManager.DeactivateShield();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    public GameObject shield;
    public static GameObject staticShield;

    private void Start()
    {
        staticShield = shield;
    }

    public static void ActivateShield(){
        staticShield.SetActive(true);
    }

    public static void DeactivateShield()
    {
        staticShield.SetActive(false);
    }
}

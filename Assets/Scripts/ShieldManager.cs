using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    public GameObject shield;
    public static GameObject staticShield;
    public static GameObject timerShield;
    public GameObject timerShieldNonstatic;

    private void Start()
    {
        staticShield = shield;
        timerShield = timerShieldNonstatic;
    }

    public static void ActivateShield(){
        staticShield.SetActive(true);
        timerShield.GetComponent<TimerShield>().resetTime();
    }

    public static void DeactivateShield()
    {
        staticShield.SetActive(false);
    }
}

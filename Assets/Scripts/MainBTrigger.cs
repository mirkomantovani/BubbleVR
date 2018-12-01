using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBTrigger : MonoBehaviour {

    public GameObject mainBaseAid;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.StartsWith("[VRTK][AUTOGEN]"))
            mainBaseAid.SetActive(false);
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;

public class SetupLocalPlayer : NetworkBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<ThirdPersonCharacter>().enabled = true;
            GetComponent<ThirdPersonUserControl>().enabled = true;
            GetComponent<BloodScreen>().enabled = true;
        }
        else
        {
            GetComponent<ThirdPersonCharacter>().enabled = false;
            GetComponent<ThirdPersonUserControl>().enabled = false;
            GetComponent<BloodScreen>().enabled = false;
            cam.enabled = false;
        }
    }
}

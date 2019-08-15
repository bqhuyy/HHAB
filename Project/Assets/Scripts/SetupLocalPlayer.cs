using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;

public class SetupLocalPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<ThirdPersonCharacter>().enabled = true;
            GetComponent<ThirdPersonUserControl>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

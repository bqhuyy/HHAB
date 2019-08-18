using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class SetupLocalPlayerTest : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<FirstPersonController>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

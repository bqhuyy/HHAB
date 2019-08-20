using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;

public class SetupLocalZombie : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<ThirdPersonCharacter>().enabled = true;
            GetComponent<AICharacterControl>().enabled = true;
        }
    }
}

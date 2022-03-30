using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRTPC : MonoBehaviour
{
    private GameObject FireExplosion;

    void Start()
    {
        GameObject.Find("FireExplosion");
        AkSoundEngine.SetRTPCValue("EventVolume", 0, FireExplosion);
    }

    void OnTriggerStay(Collider Player)
    {
        AkSoundEngine.SetRTPCValue("EventVolume", 1, FireExplosion);
    }

    void OnTriggerExit(Collider Player)
    {
        AkSoundEngine.SetRTPCValue("EventVolume", 0, FireExplosion);
    }
}

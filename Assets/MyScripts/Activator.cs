using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    //Choose which Objects to Activate, and their sound events
    public GameObject ObjectToActivate1;
    public GameObject ObjectToActivate2;
    public AK.Wwise.Event Object1Sound = null;
    public AK.Wwise.Event Object2Sound = null;

    void Start()
    {
        AkSoundEngine.SetRTPCValue("EventVolume", 0, ObjectToActivate1);
        AkSoundEngine.SetRTPCValue("EventVolume", 0, ObjectToActivate2);
    }

    void OnTriggerEnter(Collider other)
    {
        ObjectToActivate1.gameObject.SetActive(true);
        AkSoundEngine.SetRTPCValue("EventVolume", 1, ObjectToActivate1);
        ObjectToActivate2.gameObject.SetActive(true);
        AkSoundEngine.SetRTPCValue("EventVolume", 1, ObjectToActivate2);
        Object1Sound.Post(ObjectToActivate1);
        Object2Sound.Post(ObjectToActivate2);
        Destroy(gameObject); //Destroys trigger (delete this line if you need it repeatable)
    }
}

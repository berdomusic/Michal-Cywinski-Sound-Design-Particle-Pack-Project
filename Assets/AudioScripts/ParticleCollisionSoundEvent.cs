using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionSoundEvent : MonoBehaviour
{
    public ParticleSystem ps;
    public List<ParticleCollisionEvent> collisionEvents;
    private GameObject HitObject;
    private GameObject Player;

    void Start()
    {
        //HitObject = GameObject.Find("HitObject");
        Player = GameObject.Find("Player");
        ps = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        AkSoundEngine.SetRTPCValue("EventVolume", 0, HitObject);
    }

    void OnParticleCollision(GameObject Target)
    {
        HitObject = Target;
        int numCollisionEvents = ps.GetCollisionEvents(Target, collisionEvents);
        int i = 0;

        while (i < numCollisionEvents)
        {
            AkSoundEngine.PostEvent("Play_IceLanceHit", HitObject);

            i++;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
            AkSoundEngine.SetRTPCValue("EventVolume", 1, HitObject);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            AkSoundEngine.SetRTPCValue("EventVolume", 0, HitObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime;
    public float pause;
    public AnimationCurve fadeIn;

    public AK.Wwise.Event SoundEvent = null; 
    private GameObject Player;

    ParticleSystem ps;
    float timer;
    Renderer _renderer;

    int shaderProperty;

    void Start()
    {
        Player = GameObject.Find("Player");
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        var main = ps.main;
        main.duration = spawnEffectTime;
        AkSoundEngine.SetRTPCValue("EventVolume", 0, gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player)
            AkSoundEngine.SetRTPCValue("EventVolume", 1, gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            AkSoundEngine.SetRTPCValue("EventVolume", 0, gameObject);
    }

    void Update ()
    {
        if (timer <= spawnEffectTime + pause)
        {
            timer += Time.deltaTime;
        }
        else
        {
            ps.Play();
            SoundEvent.Post(gameObject);
            timer = 0;
        }


        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate( Mathf.InverseLerp(0, spawnEffectTime, timer)));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_Player : MonoBehaviour
{
    public AudioSource Jumping;
    public AudioSource Landing;
    public AudioSource Death;
    public AudioSource Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Jumping = gameObject.AddComponent<AudioSource>();
        Landing = gameObject.AddComponent<AudioSource>();
        Death = gameObject.AddComponent<AudioSource>();
        Damage = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

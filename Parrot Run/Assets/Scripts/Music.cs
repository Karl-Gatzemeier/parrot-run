using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Theme;

    public static float musicVolume = 0.3f;

    // Update is called once per frame
    void Update()
    {
        Theme.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}

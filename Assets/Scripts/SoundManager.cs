using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFX1, SFX2, SFX3, BackgroundMusic;
    static AudioSource sfx1, sfx2, sfx3, backgroundMusic;
    private void Start()
    {
        sfx1 = SFX1;
        sfx2 = SFX2;
        sfx3 = SFX3;
        backgroundMusic = BackgroundMusic;
    }
    public static void fireSFX(AudioClip sound)
    {
        if (sfx1.isPlaying)
        {
            if (sfx2.isPlaying)
            {
                if (sfx3.isPlaying)
                {
                    sfx1.clip = sound;
                    sfx1.Play();
                }
                sfx3.clip = sound;
                sfx3.Play();
            }
            sfx2.clip = sound;
            sfx3.Play();
        }
        sfx1.clip = sound;
        sfx1.Play();
    }
    public static void changeBackgroundMusic(AudioClip music)
    {
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }
    public static void pauseMusic() => backgroundMusic.Pause();
    public static void playMusic() => backgroundMusic.Play();
}
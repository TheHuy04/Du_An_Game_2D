using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //bien luu tru

    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    // bine luu tru clip

    public AudioClip musicClip;
    public AudioClip coinClip;
    public AudioClip attackClip;
    public AudioClip monsterDie;
    public AudioClip bossDie;
    public AudioClip Health;

    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }
    public void PlaySFX(AudioClip sfxClip)
    {
        vfxAudioSource.clip = sfxClip;  
        vfxAudioSource.PlayOneShot(sfxClip);
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Audio Config", menuName = "Guns/Audio Config", order = 5)]
public class AudioConfigScriptableObject : ScriptableObject 
{
    [Range(0, 1f)]
    public float volume = 1f;
    public AudioClip[] FireClips;
    public AudioClip EmptyClip;
    public AudioClip ReloadClip; 


    public void PlayShootingClip(AudioSource AudioSource)
    {
        AudioSource.PlayOneShot(FireClips[Random.Range(0, FireClips.Length)], volume);

    }

    public void PlayOutofAmmoClip(AudioSource AudioSource)
    {
        if(EmptyClip != null)
        {
            AudioSource.PlayOneShot(EmptyClip, volume);
        }
    }

    public void PlayReloadClip(AudioSource AudioSource)
    {
        if(ReloadClip != null)
        {
            AudioSource.PlayOneShot(ReloadClip, volume);
        }
    }

}

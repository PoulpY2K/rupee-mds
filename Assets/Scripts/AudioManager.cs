using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public AudioClip endClip;
    public AudioSource source;

    public void StartGame()
    {
        source.clip = music;
        source.Play();
    }

    public void StopGame()
    {
        source.Stop();
    }

    public void FinishSound()
    {
        source.clip = endClip;
        source.Play();
    }
}
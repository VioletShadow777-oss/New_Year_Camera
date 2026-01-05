using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    public AudioSource clickAudioSource;
    public AudioSource snapAudioSource;
    private void Awake()
    {
        instance = this;
    }

    // These Public Methodes will be called from Other scripts
    public void PlayClickSound()
    {
        clickAudioSource.PlayOneShot(clickAudioSource.clip);
    }

    public void PlaySnapSound()
    {
        snapAudioSource.PlayOneShot(snapAudioSource.clip);
    }
}

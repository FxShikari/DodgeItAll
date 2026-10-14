using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private AudioSource _source;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, kill myself NOW.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void StartPlayingMusic()
    {
        _source.Play();
    }

    public void StopMusic()
    {
        _source.Stop();
    }

    public void PlayClip(AudioClip clip, Vector3 where, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, where, volume);
    }
}

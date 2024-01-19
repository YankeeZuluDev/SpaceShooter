using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for playing music and SFX
/// </summary>

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sFXSource;
    [SerializeField] private List<Sound> sounds;

    private Dictionary<AudioID, Sound> soundsDictionary;

    private void Awake() => InitializeSoundsDictionary();

    private void Start() => PlayMusic();

    private void InitializeSoundsDictionary()
    {
        soundsDictionary = new(sounds.Count);

        foreach (Sound sound in sounds)
        {
            soundsDictionary.Add(sound.AudioID, sound);
        }
    }

    private void PlayMusic()
    {
        musicSource.clip = soundsDictionary[AudioID.Music].Clip;
        musicSource.volume = soundsDictionary[AudioID.Music].Volume;
        musicSource.Play();
    }

    public void PlaySFX(AudioID audioID)
    {
        if (soundsDictionary.ContainsKey(audioID))
            sFXSource.PlayOneShot(soundsDictionary[audioID].Clip, soundsDictionary[audioID].Volume);
        else
            throw new KeyNotFoundException($"No clip with {audioID} ID was found in dictionary");
    }
}

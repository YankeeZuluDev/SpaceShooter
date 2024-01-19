using UnityEngine;

/// <summary>
/// This is a container for AudioClip, AudioId and audio Volume
/// </summary>

[System.Serializable]
public struct Sound
{
    public AudioID AudioID;
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
}

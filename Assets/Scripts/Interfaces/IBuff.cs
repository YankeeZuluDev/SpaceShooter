using UnityEngine;

/// <summary>
/// An interface for buff
/// </summary>

public interface IBuff
{
    GameObject GameObject { get; }
    float Duration { get; }
}

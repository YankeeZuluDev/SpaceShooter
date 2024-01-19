using UnityEngine;

public class InvincibilityBuff : MonoBehaviour, IBuff
{
    [SerializeField] private float duration;

    public GameObject GameObject => gameObject;
    public float Duration => duration;

}

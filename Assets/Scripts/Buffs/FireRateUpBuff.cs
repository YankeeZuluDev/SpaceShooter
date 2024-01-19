using UnityEngine;

public class FireRateUpBuff : MonoBehaviour, IBuff
{
    [SerializeField] private float duration;
    [SerializeField] private float fireRateAmount;

    public float Duration => duration;
    public GameObject GameObject => gameObject;
    public float FireRateAmount => fireRateAmount;
}

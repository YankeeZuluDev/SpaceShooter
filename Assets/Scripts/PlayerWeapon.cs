using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform barrelTransform;
    [SerializeField] private float shotSpeed;
    [SerializeField] private float fireRate;

    private BulletPool bulletPool;
    private IInputHandler inputHandler;
    private AudioManager audioManager;
    private bool allowShooting;
    private bool isOnFireRateCooldown;
    private bool isFireRateBuffed;

    public bool IsFireRateBuffed => isFireRateBuffed;

    [Inject]
    private void Construt(BulletPool bulletPool, IInputHandler inputHandler, AudioManager audioManager)
    {
        this.bulletPool = bulletPool;
        this.inputHandler = inputHandler;
        this.audioManager = audioManager;
    }

    private void Awake() => AllowShooting();

    private void Update()
    {
        if (inputHandler.PlayerIsClicking)
            Shoot();
    }

    public void AllowShooting() => allowShooting = true;

    public void StopShooting() => allowShooting = false;

    private void Shoot()
    {
        if (!allowShooting || isOnFireRateCooldown) return;

        StartCoroutine(FireRateCooldown());

        Bullet bullet = bulletPool.Pool.Get();

        bullet.transform.SetPositionAndRotation(barrelTransform.position, barrelTransform.rotation);

        Vector2 direction = Vector2.up;

        bullet.StartMovingAndRotating(direction, shotSpeed);

        audioManager.PlaySFX(AudioID.LaserShot);
    }

    private IEnumerator FireRateCooldown()
    {
        isOnFireRateCooldown = true;

        yield return new WaitForSeconds(fireRate);

        isOnFireRateCooldown = false;
    }

    public void ApplyFireRateUpBuff(float fireDelayDecreaseAmount, float duration)
    {
        StartCoroutine(ApplyFireRateUpBuffCoroutine(fireDelayDecreaseAmount, duration));
    }

    private IEnumerator ApplyFireRateUpBuffCoroutine(float fireDelayDecreaseAmount, float duration)
    {
        isFireRateBuffed = true;

        fireRate -= fireDelayDecreaseAmount;

        yield return new WaitForSeconds(duration);

        fireRate += fireDelayDecreaseAmount;

        isFireRateBuffed = false;
    }
}

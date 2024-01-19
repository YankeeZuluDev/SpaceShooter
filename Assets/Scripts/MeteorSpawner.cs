using System.Collections;
using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for initializing random meteor propperties and spawning it
/// </summary>

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private float meteorSpawnRadius;
    [SerializeField] private float minMeteorMovementSpeed;
    [SerializeField] private float maxMeteorMovementSpeed;
    [SerializeField] private float minMeteorRotationSpeed;
    [SerializeField] private float maxMeteorRotationSpeed;

    private MeteorPool meteorPool;
    private ScreenInfoKeeper screenInfo;
    private bool allowSpawn;

    [Inject]
    private void Construct(MeteorPool meteorPool, ScreenInfoKeeper screenInfo)
    {
        this.meteorPool = meteorPool;
        this.screenInfo = screenInfo;
    }

    private void Awake()
    {
        AllowSpawningOverTime();
        StartCoroutine(SpawnMeteorsOverTime());
    }

    private Vector2 GetRandomMeteorRefPoint()
    {
        float randomX = Random.Range(-screenInfo.HalfScreenX, screenInfo.HalfScreenX);
        
        return new Vector2(randomX, 0); ;
    }

    private Vector2 GetRandomMeteorSpawnPosition() => Random.insideUnitCircle.normalized * meteorSpawnRadius;

    private float GetRandomMeteorMovementSpeed() => Random.Range(minMeteorMovementSpeed, maxMeteorMovementSpeed);
    
    private float GetRandomMeteorRotationSpeed() => Random.Range(minMeteorRotationSpeed, maxMeteorRotationSpeed);

    private void SpawnMeteor()
    {
        Meteor meteor = meteorPool.Pool.Get();

        Vector2 refPoint = GetRandomMeteorRefPoint();
        Vector2 spawnPosition = GetRandomMeteorSpawnPosition();

        // Calculate direction from reference point
        Vector2 direction = (refPoint - spawnPosition).normalized;

        float movementSpeed = GetRandomMeteorMovementSpeed();
        float rotationSpeed = GetRandomMeteorRotationSpeed();

        meteor.transform.position = spawnPosition;
        meteor.SetRotationSpeed(rotationSpeed);
        meteor.StartMovingAndRotating(direction, movementSpeed);
    }

    public void AllowSpawningOverTime() => allowSpawn = true;

    public void StopSpawningOverTime() => allowSpawn = false;

    public IEnumerator SpawnMeteorsOverTime()
    {
        while (allowSpawn)
        {
            SpawnMeteor();

            yield return new WaitForSeconds(spawnRate);
        }
    }
}

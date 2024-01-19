using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// This class is responsible for picking random buff and spawning it
/// </summary>

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;
    [SerializeField] private List<GameObject> buffPrefabList;

    private List<IBuff> buffList;
    private ScreenInfoKeeper screenInfo;
    private BuffFactory buffFactory;
    private bool allowSpawn;

    [Inject]
    private void Construct(ScreenInfoKeeper screenInfo, BuffFactory buffFactory)
    {
        this.screenInfo = screenInfo;
        this.buffFactory = buffFactory;
    }

    private void Awake() => InitializeBuffList();

    private void Start() => Invoke(nameof(SpawnRandomBuff), GetRandomSpawnDelay());

    private void InitializeBuffList()
    {
        buffList = new List<IBuff>(buffPrefabList.Count);

        foreach (GameObject buffPrefab in buffPrefabList)
        {
            // Instantiate each buff from buffPrefabList
            IBuff buff = buffFactory.Create(buffPrefab, transform);

            // Add buff to buffList
            buffList.Add(buff);

            // Hide buff
            buff.GameObject.SetActive(false);
        }
    }

    private Vector2 GetRandomBuffSpawnPosition()
    {
        float randomX = Random.Range(-screenInfo.HalfScreenX, screenInfo.HalfScreenX);
        float randomY = Random.Range(-screenInfo.HalfScreenY, screenInfo.HalfScreenY);

        return new Vector2(randomX, randomY);
    }

    private float GetRandomSpawnDelay() => Random.Range(minSpawnDelay, maxSpawnDelay);

    private void SpawnRandomBuff()
    {
        // Get random buff from list
        IBuff randomBuff = buffList[Random.Range(0, buffList.Count)];

        // Calculate random spawn position
        Vector2 spawnPosition = GetRandomBuffSpawnPosition();

        // Set position
        randomBuff.GameObject.transform.position = spawnPosition;

        // Show buff
        randomBuff.GameObject.SetActive(true);
    }

    public void ReleaseBuffAndSpawnNext(IBuff buff)
    {
        // Hide buff
        buff.GameObject.SetActive(false);

        // Spawn random buff after random delay
        Invoke(nameof(SpawnRandomBuff), GetRandomSpawnDelay());
    }
}

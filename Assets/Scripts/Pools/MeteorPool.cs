using UnityEngine;
using UnityEngine.Pool;
using Zenject;

/// <summary>
/// An object pool for meteors
/// </summary>

public class MeteorPool : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [Space()]
    [SerializeField] private Sprite[] meteorSprites;

    private ObjectPool<Meteor> pool;
    private MeteorFactory meteorFactory;

    public ObjectPool<Meteor> Pool => pool;

    [Inject]
    private void Construct(MeteorFactory meteorFactory)
    {
        this.meteorFactory = meteorFactory;
    }

    private void Awake()
    {
        pool = new ObjectPool<Meteor>(
            () => meteorFactory.Create(meteorPrefab, transform), 
            OnGet, 
            OnRelease, 
            OnKill, 
            false);
    }

    private void OnGet(Meteor meteor)
    {
        meteor.gameObject.SetActive(true);
        meteor.MeteorSpriteRenderer.sprite = GetRandomMeteorSprite();
    }

    private void OnRelease(Meteor meteor)
    {
        meteor.gameObject.SetActive(false);
    }

    private void OnKill(Meteor meteor)
    {
        Destroy(meteor.gameObject);
    }

    private Sprite GetRandomMeteorSprite()
    {
        return meteorSprites[Random.Range(0, meteorSprites.Length)];
    }
}

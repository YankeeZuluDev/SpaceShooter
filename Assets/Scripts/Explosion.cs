using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]

public class Explosion : MonoBehaviour
{
    [SerializeField] private AnimationClip explosionAnimationClip;

    private ExplosionPool explosionPool;
    private Animator animator;
    private const string explosionTrigger = "explosion";

    [Inject]
    private void Construct(ExplosionPool explosionPool) => this.explosionPool = explosionPool;

    private void Awake() => animator = GetComponent<Animator>();

    public void Explode() => StartCoroutine(ExplodeCoroutine());

    private IEnumerator ExplodeCoroutine()
    {
        animator.SetTrigger(explosionTrigger);

        yield return new WaitForSeconds(explosionAnimationClip.length);

        explosionPool.Pool.Release(this);
    }
}

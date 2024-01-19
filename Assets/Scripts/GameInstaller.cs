using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject inputHandlerPrefab;
    [SerializeField] private GameObject bulletPoolPrefab;
    [SerializeField] private GameObject meteorPoolPrefab;
    [SerializeField] private GameObject explosionPoolPrefab;
    [SerializeField] private GameObject scorePopupPoolPrefab;
    [SerializeField] private GameObject meteorSpawnerPrefab;
    [SerializeField] private GameObject buffSpawnerPrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject screenInfoKeeperPrefab;
    [SerializeField] private GameObject scoreManagerPrefab;
    [SerializeField] private GameObject uIManagerPrefab;
    [SerializeField] private GameObject audioManagerPrefab;
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private GameObject backgroundManagerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<IInputHandler>().To<InputHandler>().FromComponentInNewPrefab(inputHandlerPrefab).AsSingle().NonLazy();
        Container.Bind<BulletPool>().FromComponentInNewPrefab(bulletPoolPrefab).AsSingle().NonLazy();
        Container.Bind<MeteorPool>().FromComponentInNewPrefab(meteorPoolPrefab).AsSingle().NonLazy();
        Container.Bind<ExplosionPool>().FromComponentInNewPrefab(explosionPoolPrefab).AsSingle().NonLazy();
        Container.Bind<ScorePopupPool>().FromComponentInNewPrefab(scorePopupPoolPrefab).AsSingle().NonLazy();
        Container.Bind<MeteorSpawner>().FromComponentInNewPrefab(meteorSpawnerPrefab).AsSingle().NonLazy();
        Container.Bind<BuffSpawner>().FromComponentInNewPrefab(buffSpawnerPrefab).AsSingle().NonLazy();
        Container.Bind<Camera>().FromComponentInNewPrefab(cameraPrefab).AsSingle().NonLazy();
        Container.Bind<ScreenInfoKeeper>().FromComponentInNewPrefab(screenInfoKeeperPrefab).AsSingle().NonLazy();
        Container.Bind<ScoreManager>().FromComponentInNewPrefab(scoreManagerPrefab).AsSingle().NonLazy();
        Container.Bind<UIManager>().FromComponentInNewPrefab(uIManagerPrefab).AsSingle().NonLazy();
        Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManagerPrefab).AsSingle().NonLazy();
        Container.Bind<BackgroundManager>().FromComponentInNewPrefab(backgroundManagerPrefab).AsSingle().NonLazy();
        Container.Bind<ExplosionFactory>().AsSingle().NonLazy();
        Container.Bind<BulletFactory>().AsSingle().NonLazy();
        Container.Bind<MeteorFactory>().AsSingle().NonLazy();
        Container.Bind<BuffFactory>().AsSingle().NonLazy();
        Container.Bind<ScorePopupFactory>().AsSingle().NonLazy();
        Container.Bind<PlayerWeapon>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
    }
}
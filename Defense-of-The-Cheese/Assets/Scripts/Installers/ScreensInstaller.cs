using UnityEngine;
using Zenject;

public class ScreensInstaller : MonoInstaller
{
    [SerializeField] private Screens screensPrefab;

    public override void InstallBindings()
    {
        var screens =
            Container.InstantiatePrefabForComponent<Screens>(
                screensPrefab,
                Vector3.zero,
                Quaternion.identity,
                null
                );

        Container.Bind<Screens>().
            FromInstance(screens).
            AsSingle().
            NonLazy();
    }
}

using UnityEngine;
using Zenject;

public class TowerInstaller : MonoInstaller
{
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private Transform towerSpawnPosition;

    public override void InstallBindings()
    {
        var tower =
            Container.InstantiatePrefabForComponent<Tower>(
                towerPrefab,
                towerSpawnPosition.position,
                Quaternion.identity,
                null
                );

        Container.Bind<Tower>().
            FromInstance(tower).
            AsSingle().
            NonLazy();
    }
}

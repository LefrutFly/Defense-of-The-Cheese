using UnityEngine;

public class DeathDestroySystem : BaseSystem, IStartableSystem, IDestroySystem
{
    public void Start()
    {
        if (IsActive == false) return;

        if (Providers.Has<HealthProvider>() == false) return;

        var health = Providers.Get<HealthProvider>().component;

        health.ZeroHp += () => DestroyActor();
    }

    public void Destroy()
    {
        if (Providers.Has<HealthProvider>() == false) return;

        var health = Providers.Get<HealthProvider>().component;

        health.ZeroHp -= () => DestroyActor();
    }

    private void DestroyActor()
    {
        MonoBehaviour.Destroy(Actor.gameObject);
    }
}
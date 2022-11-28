using UnityEngine;

public class DeathResetPlayerSystem : BaseSystem, IEnableSystem
{
    public void Enable()
    {
        if (Providers.TryGet(out HealthProvider healthProvider))
        {
            healthProvider.component.HealthNow = healthProvider.component.HealthMax;
        }
    }
}
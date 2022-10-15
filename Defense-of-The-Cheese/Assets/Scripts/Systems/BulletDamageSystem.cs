using UnityEngine;

public class BulletDamageSystem : BaseSystem, ITriggableSystem
{
    public void TriggetEnter(Collider2D collision)
    {
        if (IsActive == false) return;

        if(collision.TryGetComponent(out Enemy entity))
        {
            if(entity.Providers.TryGet(out HealthProvider healthProvider))
            {
                var health = healthProvider.component;

                if(Providers.TryGet(out BulletProvider bulletProvider))
                {
                    var damage = bulletProvider.component.Damage;
                    health.HealthNow -= damage;
                }
            }
            MonoBehaviour.Destroy(Actor.gameObject);
        }
    }

    public void TriggetExit(Collider2D collision)
    {
        
    }

    public void TriggetStay(Collider2D collision)
    {
        
    }
}
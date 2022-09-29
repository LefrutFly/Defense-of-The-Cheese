using UnityEngine;

public class BulletDamageSystem : BaseSystem, ITriggableSystem
{
    public void TriggetEnter(Collider2D collision)
    {
        if(collision.TryGetComponent(out Entity entity))
        {
            if(entity.Providers.TryGet(out HealthProvider healthProvider))
            {
                var health = healthProvider.component;

                if(Providers.TryGet(out BulletProvider bulletProvider))
                {
                    var damage = bulletProvider.component.Damage;
                    health.healthNow -= damage;
                }
            }
        }
        MonoBehaviour.Destroy(Actor.gameObject);
    }

    public void TriggetExit(Collider2D collision)
    {
        
    }

    public void TriggetStay(Collider2D collision)
    {
        
    }
}
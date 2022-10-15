﻿using System.Collections;
using UnityEngine;

public class EnemtAttackSystem : BaseSystem, ITriggableSystem
{
    private Coroutine damage;

    public void TriggetEnter(Collider2D collision)
    {
        if (IsActive == false) return;

        if (Providers.Has<PeriodicTriggerDamageProvider>() == false) return;

        ref var periodicTriggerDamageComponent = ref Providers.Get<PeriodicTriggerDamageProvider>().component;

        if (collision.TryGetComponent(out Entity entity))
        {
            if (damage == null)
            {
                damage = Coroutines.Start(TakeDamage(entity, periodicTriggerDamageComponent));
            }
        }
    }

    public void TriggetExit(Collider2D collision)
    {
        if (Providers.Has<PeriodicTriggerDamageProvider>() == false) return;

        if (collision.TryGetComponent(out Entity entity))
        {
            if (damage != null)
            {
                Coroutines.Stop(damage);
                damage = null;
            }
        }
    }

    public void TriggetStay(Collider2D collision)
    {

    }

    private IEnumerator TakeDamage(Entity entity, PeriodicTriggerDamageComponent component)
    {
        var damage = component.damage;
        var cooldown = component.cooldown;

        if (entity.Providers.Has<HealthProvider>() == false) yield break;

        while (true)
        {
            entity.Providers.Get<HealthProvider>().component.HealthNow -= damage;

            yield return new WaitForSeconds(cooldown);

            if (entity.gameObject.activeSelf == false)
            {
                break;
            }
        }
        if (this.damage != null)
        {
            Coroutines.Stop(this.damage);
            this.damage = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private GameObject view;

    private HealthComponent healthComponent;

    private void OnEnable()
    {
        if(entity.Providers.TryGet(out HealthProvider provider))
        {
            healthComponent = provider.component;
            healthComponent.ChangedHealthNow += UpdateUI;
        }
    }

    private void OnDisable()
    {
        if (entity.Providers.TryGet(out HealthProvider provider))
        {
            healthComponent = provider.component;
            healthComponent.ChangedHealthNow -= UpdateUI;
        }
    }

    private void UpdateUI()
    {
        var hpNow = healthComponent.HealthNow;
        var hpMax = healthComponent.HealthMax;

        view.transform.localScale = new Vector3(hpNow / hpMax, 1, 1);
    }
}

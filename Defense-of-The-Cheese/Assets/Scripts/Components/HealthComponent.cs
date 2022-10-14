using System;
using UnityEngine;

[System.Serializable]
public class HealthComponent
{
    public event Action ChangedHealthNow;
    public event Action ChangedHealthMax;
    public event Action ZeroHp;

    [SerializeField] private float healthMax;
    [SerializeField] private float healthNow;

    public float HealthMax
    {
        get { return healthMax; }
        set
        {
            healthMax = value;
            if (healthMax < HealthNow)
            {
                healthMax = value;            
            }
            ChangedHealthMax?.Invoke();
        }
    }

    public float HealthNow
    {
        get { return healthNow; }
        set
        {
            if (value > healthNow)
            {
                healthNow = value;
            }
            else if (value <= 0)
            {
                healthNow = 0;
                ZeroHp?.Invoke();
            }
            else
            {
                healthNow = value;
            }
            ChangedHealthNow?.Invoke();
        }
    }
}

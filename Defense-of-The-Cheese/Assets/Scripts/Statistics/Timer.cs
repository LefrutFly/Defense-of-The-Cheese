using UnityEngine;
using Zenject;

public class Timer : MonoBehaviour
{
    [Inject] private Statistics statistics;

    public bool IsStartedTimer = false;

    private void Start()
    {
        statistics.TimeNow = 0;
    }

    private void Update()
    {
        if (IsStartedTimer)
        {
            statistics.TimeNow += Time.deltaTime;
        }
    }
}
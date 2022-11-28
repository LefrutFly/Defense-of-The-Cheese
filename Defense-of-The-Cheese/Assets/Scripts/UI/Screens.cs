using System;
using UnityEngine;

public class Screens : MonoBehaviour
{
    public event Action startScreenEnabledEvent;
    public event Action startScreenDisabledEvent;
    public event Action inGameScreenEnabledEvent;
    public event Action inGameScreenDiabledEvent;
    public event Action loseScreenEnabledEvent;
    public event Action loseScreenDisabledEvent;

    [SerializeField] private StartProjectScreen startProjectScreen;
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private LoseScreen loseScreen;

    public StartProjectScreen StartProjectScreen => startProjectScreen;
    public GameObject InGameScreen => inGameScreen;
    public LoseScreen LoseScreen => loseScreen;

    public void EnableStartProjectScreen()
    {
        startProjectScreen.gameObject.SetActive(true);
        startScreenEnabledEvent?.Invoke();
    }

    public void DisableStartProjectScreen()
    {
        startProjectScreen.gameObject.SetActive(false);
        startScreenDisabledEvent?.Invoke();
    }

    public void EnableInGameScreen()
    {
        inGameScreen.gameObject.SetActive(true);
        inGameScreenEnabledEvent?.Invoke();
    }

    public void DisableInGameScreen()
    {
        inGameScreen.gameObject.SetActive(false);
        inGameScreenDiabledEvent?.Invoke();
    }

    public void EnableLoseScreen()
    {
        loseScreen.gameObject.SetActive(true);
        loseScreenEnabledEvent?.Invoke();
    }

    public void DisableLoseScreen()
    {
        loseScreen.gameObject.SetActive(false);
        loseScreenDisabledEvent?.Invoke();
    }
}

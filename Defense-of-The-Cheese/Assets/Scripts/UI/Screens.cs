using System;
using UnityEngine;
using Zenject;

public class Screens : MonoBehaviour
{
    public event Action startScreenEnabledEvent;
    public event Action startScreenDisabledEvent;
    public event Action inGameScreenEnabledEvent;
    public event Action inGameScreenDiabledEvent;
    public event Action pauseScreenEnabledEvent;
    public event Action pauseScreenDisabledEvent;
    public event Action loseScreenEnabledEvent;
    public event Action loseScreenDisabledEvent;
    public event Action wonScreenEnabledEvent;
    public event Action wonScreenDiabledEvent;

    [SerializeField] private StartProjectScreen startProjectScreen;
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private GameObject pauseGameScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject wonScreen;

    public StartProjectScreen StartProjectScreen => startProjectScreen;
    public GameObject InGameScreen => inGameScreen;
    public GameObject PauseGameScreen => pauseGameScreen;
    public GameObject LoseScreen => loseScreen;
    public GameObject WonScreen => wonScreen;

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

    public void EnablePauseGameScreen()
    {
        pauseGameScreen.gameObject.SetActive(true);
        pauseScreenEnabledEvent?.Invoke();
    }

    public void DisablePauseGameScreen()
    {
        pauseGameScreen.gameObject.SetActive(false);
        pauseScreenDisabledEvent?.Invoke();
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

    public void EnableWonScreen()
    {
        wonScreen.gameObject.SetActive(true);
        wonScreenEnabledEvent?.Invoke();
    }

    public void DisableWonScreen()
    {
        wonScreen.gameObject.SetActive(false);
        wonScreenDiabledEvent?.Invoke();
    }
}

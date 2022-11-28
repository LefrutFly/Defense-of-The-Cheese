using System.Collections;
using UnityEngine;

public class BeginState : State
{
    private GameStateMachine gameStateMachine;
    public BeginState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;

        gameStateMachine.Screens.EnableStartProjectScreen();
        StopTime();
        SetCameraInStartScreen();
        DisablePlayer();

        gameStateMachine.Screens.StartProjectScreen.StartGameButton.onClick.AddListener(StartGame);

        yield break;
    }

    public override IEnumerator End()
    {
        PlayTime();
        EnablePlayer();
        gameStateMachine.Screens.DisableStartProjectScreen();

        gameStateMachine.Screens.StartProjectScreen.StartGameButton.onClick.RemoveListener(StartGame);

        yield break;
    }


    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void PlayTime()
    {
        Time.timeScale = 1;
    }

    private void SetCameraInStartScreen()
    {
        gameStateMachine.Screens.StartProjectScreen.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void DisablePlayer()
    {
        gameStateMachine.Player.gameObject.SetActive(false);
    }

    private void EnablePlayer()
    {
        gameStateMachine.Player.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        gameStateMachine.SetState(new InGameState(gameStateMachine));
    }
}

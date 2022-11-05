using System.Collections;
using UnityEngine;

public class InGameState : State
{
    private GameStateMachine gameStateMachine;
    public InGameState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;

        gameStateMachine.Screens.DisableStartProjectScreen();
        gameStateMachine.Screens.EnableInGameScreen();
        EnablePlayer();

        yield break;
    }

    public override IEnumerator End()
    {
        gameStateMachine.Screens.DisableInGameScreen();

        yield break;
    }

    private void EnablePlayer()
    {
        gameStateMachine.Player.gameObject.SetActive(true);
    }
}
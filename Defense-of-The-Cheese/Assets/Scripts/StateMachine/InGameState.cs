using System.Collections;
using UnityEngine;

public class InGameState : State
{
    private GameStateMachine gameStateMachine;
    public InGameState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;

        EnableInGameScreen();
        SubscribeToLoseStatePlayer();
        SubscribeToLoseStateTower();
        gameStateMachine.EnemySpawner.LaunchSpawn();
        gameStateMachine.Timer.IsStartedTimer = true;

        yield break;
    }

    public override IEnumerator End()
    {
        DisableInGameScreen();
        UnsubscribeToLoseStatePlayer();
        UnsubscribeToLoseStateTower();
        DisablePlayer();
        gameStateMachine.EnemySpawner.StopSpawn();
        gameStateMachine.Timer.IsStartedTimer = false;

        yield break;
    }

    private void DisablePlayer()
    {
        gameStateMachine.Player.gameObject.SetActive(false);
    }

    private void SubscribeToLoseStatePlayer()
    {
        if (gameStateMachine.Player.Providers.TryGet(out HealthProvider healthProvider))
        {
            healthProvider.component.ZeroHp += GoLoseState;
        }
    }

    private void UnsubscribeToLoseStatePlayer()
    {
        if (gameStateMachine.Player.Providers.TryGet(out HealthProvider healthProvider))
        {
            healthProvider.component.ZeroHp -= GoLoseState;
        }
    }

    private void SubscribeToLoseStateTower()
    {
        if (gameStateMachine.Tower.Providers.TryGet(out HealthProvider healthProvider))
        {
            healthProvider.component.ZeroHp += GoLoseState;
        }
    }

    private void UnsubscribeToLoseStateTower()
    {
        if (gameStateMachine.Tower.Providers.TryGet(out HealthProvider healthProvider))
        {
            healthProvider.component.ZeroHp -= GoLoseState;
        }
    }

    private void EnableInGameScreen()
    {
        gameStateMachine.Screens.EnableInGameScreen();
    }

    private void DisableInGameScreen()
    {
        gameStateMachine.Screens.DisableInGameScreen();
    }

    private void GoLoseState()
    {
        gameStateMachine.SetState(new LoseState(gameStateMachine));
    }
}

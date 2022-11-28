using System.Collections;
using UnityEngine.SceneManagement;

public class LoseState : State
{
    private GameStateMachine gameStateMachine;
    public LoseState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;

        gameStateMachine.Statistics.LoadStatistics();
        gameStateMachine.Statistics.WriteKills();
        gameStateMachine.Statistics.WriteBullets();
        gameStateMachine.Statistics.WriteTime();

        gameStateMachine.Screens.EnableLoseScreen();
        gameStateMachine.Screens.LoseScreen.RestartGameButton.onClick.AddListener(RestartGame);

        yield break;
    }

    public override IEnumerator End()
    {
        gameStateMachine.Screens.LoseScreen.RestartGameButton.onClick.RemoveListener(RestartGame);

        gameStateMachine.EnemySpawner.DeleteAllEnemies();
        gameStateMachine.Screens.DisableLoseScreen();

        yield break;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameStateMachine.SetState(new BeginState(gameStateMachine));
    }
}
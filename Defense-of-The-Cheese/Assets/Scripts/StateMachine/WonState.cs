using System.Collections;

public class WonState : State
{
    private GameStateMachine gameStateMachine;
    public WonState(StateMachine stateMachine) : base(stateMachine) { }

    public override IEnumerator Start()
    {
        gameStateMachine = stateMachine as GameStateMachine;

        yield break;
    }

    public override IEnumerator End()
    {
        yield break;
    }
}

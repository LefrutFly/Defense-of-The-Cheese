using Zenject;

public class Player : Entity
{
    [Inject] public Statistics Statistics;

    protected override void Initialize()
    {
        AddSystem(new PlayerDirectionSystem());
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new PlayerViewDirectionSystem());
        AddSystem(new PlayerShootingSystem());
        AddSystem(new DeathResetPlayerSystem());
    }
}
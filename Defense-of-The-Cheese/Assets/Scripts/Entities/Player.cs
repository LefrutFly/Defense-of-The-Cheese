public class Player : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PlayerDirectionSystem());
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new ViewDirectionSystem());
        AddSystem(new PlayerShootingSystem());
        AddSystem(new DeathDestroySystem());
    }
}
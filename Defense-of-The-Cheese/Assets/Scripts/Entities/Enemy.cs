public class Enemy : Entity
{
    protected override void Initialize()
    {
        AddSystem(new EnemyDirectionFinderSystem());
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new DeathDestroySystem());
    }
}

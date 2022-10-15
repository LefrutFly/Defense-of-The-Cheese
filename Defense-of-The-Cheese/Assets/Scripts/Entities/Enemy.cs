public class Enemy : Entity
{
    protected override void Initialize()
    {
        AddSystem(new EnemyDirectionFinderSystem());
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new ViewDirectionSystem());
        AddSystem(new EnemtAttackSystem());
        AddSystem(new DeathDestroySystem());
    }
}

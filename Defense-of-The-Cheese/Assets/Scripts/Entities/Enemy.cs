public class Enemy : Entity
{
    public Statistics Statistics;

    protected override void Initialize()
    {
        AddSystem(new EnemyDirectionFinderSystem());
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new ViewDirectionSystem());
        AddSystem(new EnemyAttackSystem());
        AddSystem(new EnemyDeathDestroySystem());
    }
}

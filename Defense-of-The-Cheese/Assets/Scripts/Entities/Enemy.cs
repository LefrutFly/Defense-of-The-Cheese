public class Enemy : Entity
{
    protected override void Initialize()
    {
        AddSystem(new DeathDestroySystem());
    }
}

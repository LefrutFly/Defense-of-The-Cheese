public class Tower : Entity
{
    protected override void Initialize()
    {
        AddSystem(new DeathResetPlayerSystem());
    }
}

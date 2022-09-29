public class Bullet : Entity
{
    protected override void Initialize()
    {
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new BulletDamageSystem());
    }
}

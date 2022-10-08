using Photon.Pun;
using UnityEngine;

public class RigidbodyMoveSystem : BaseSystem, IFixedUpdatableSystem
{
    public void FixedUpdate()
    {
        if (Actor.TryGetComponent(out PhotonView photonView))
        {
            if (photonView.IsMine == false) return;
        }

        if (IsActive == false) return;

        if (Providers.Has<DirectionProvider>() == false ||
            Providers.Has<MoveProvider>() == false)
            return;

        var Direction = Providers.Get<DirectionProvider>().component;
        var Movement = Providers.Get<MoveProvider>().component;

        Move(Direction, Movement);
    }

    private void Move(DirectionComponent directionComponent, MoveComponent move)
    {
        var localDirection = directionComponent.Direction;

        var target = move.Target;
        var speed = move.Speed;

        var direction = new Vector2();

        if (localDirection == new Vector2(0, 0))
        {
            direction = new Vector2(0, 0);
        }
        else
        {
            var localAngel = localDirection.DirectionToAngel();
            var transformAngel = target.transform.rotation.eulerAngles.z;

            direction = (localAngel + transformAngel).DegreeInVector2D();
        }

        if (target.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = speed * direction * Time.deltaTime;
        }
        else
        {
            Debug.LogError(Actor.name + " does not have a Rigidbody2D component!");
            return;
        }
    }
}

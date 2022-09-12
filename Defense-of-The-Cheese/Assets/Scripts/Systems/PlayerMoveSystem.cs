using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem : BaseSystem, IFixedUpdatableSystem
{
    public void FixedUpdate()
    {
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
        var direction = directionComponent.Direction;

        var target = move.Target;
        var speed = move.Speed;

        if (target.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = speed * direction * Time.deltaTime;
        }
        else
        {
            return;
        }
    }
}

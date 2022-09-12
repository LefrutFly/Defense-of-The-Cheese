using UnityEngine;

public class PlayerDirectionSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<DirectionProvider>() == false ||
           Providers.Has<PlayerMoveKeysProvider>() == false)
            return;

        var Direction = Providers.Get<DirectionProvider>().component;
        var PlayerMoveKeys = Providers.Get<PlayerMoveKeysProvider>().component;

        ChooseDirection(Direction, PlayerMoveKeys);
    }

    private void ChooseDirection(DirectionComponent directionComponent, PlayerMoveKeysComponent keysComponent)
    {
        var direction = new Vector3(0, 0, 0);
        var left = keysComponent.Left;
        var right = keysComponent.Right;
        var up = keysComponent.Up;
        var down = keysComponent.Down;

        bool wasPush = false;

        if (Input.GetKey(left))
        {
            direction.x = -1;
            wasPush = true;
        }
        if (Input.GetKey(right))
        {
            direction.x = 1;
            wasPush = true;
        }
        if (Input.GetKey(up))
        {
            direction.y = 1;
            wasPush = true;
        }
        if (Input.GetKey(down))
        {
            direction.y = -1;
            wasPush = true;
        }

        if (wasPush == false)
        {
            direction = Vector3.zero;
        }

        direction = direction.normalized;

        directionComponent.Direction = direction;
    }
}

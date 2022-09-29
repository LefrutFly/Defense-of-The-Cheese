using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PlayerDirectionSystem());
        AddSystem(new RigidbodyMoveSystem());
        AddSystem(new ViewDirectionSystem());
        AddSystem(new PlayerShootingSystem());
    }
}

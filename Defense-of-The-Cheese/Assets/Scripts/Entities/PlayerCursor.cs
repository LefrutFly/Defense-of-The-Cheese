using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : Entity
{
    protected override void Initialize()
    {
        AddSystem(new PointCursorSystem());
    }
}

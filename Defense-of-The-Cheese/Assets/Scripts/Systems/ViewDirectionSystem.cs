using UnityEngine;

public class ViewDirectionSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<ViewProvider>() == false ||
            Providers.Has<DirectionProvider>() == false
            )
            return;

        var view = Providers.Get<ViewProvider>().component.view;
        var direction = Providers.Get<DirectionProvider>().component.Direction;
        var viewDirection = (Vector2)view.transform.position + direction;

        view.Look2D(viewDirection);
    }
}
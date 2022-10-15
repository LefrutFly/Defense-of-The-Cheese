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

        if(direction.x >= 0)
        {
            view.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            view.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
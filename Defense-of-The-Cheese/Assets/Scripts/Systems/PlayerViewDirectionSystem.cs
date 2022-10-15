using UnityEngine;

public class PlayerViewDirectionSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<ViewProvider>() == false)
            return;

        ref var view = ref Providers.Get<ViewProvider>().component.view;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Actor.transform.position;

        if (direction.x > 0)
        {
            view.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(direction.x < 0)
        {
            view.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}

using UnityEngine;

public class PointCursorSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if(IsActive == false) return ;

        if (Providers.Has<ViewProvider>() == false) return;

        var view = Providers.Get<ViewProvider>().component.view;

        PointToCursor(view);
    }

    private void PointToCursor(GameObject view)
    {
        view.Look2D(Camera.main.ScreenToWorldPoint(Input.mousePosition));      
    }
}

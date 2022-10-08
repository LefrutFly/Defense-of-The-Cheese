using Photon.Pun;
using UnityEngine;

public class ViewDirectionSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (Actor.TryGetComponent(out PhotonView photonView))
        {
            if (photonView.IsMine == false) return;
        }

        if (IsActive == false) return;

        if (Providers.Has<ViewProvider>() == false)
            return;

        ref var view = ref Providers.Get<ViewProvider>().component.view;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Actor.transform.position;

        if (direction.x > 0)
        {
            view.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        }
        if(direction.x < 0)
        {
            view.transform.rotation = UnityEngine.Quaternion.Euler(0, 180, 0);
        }
    }
}

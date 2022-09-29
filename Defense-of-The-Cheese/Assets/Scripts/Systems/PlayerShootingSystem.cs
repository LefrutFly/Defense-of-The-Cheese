using UnityEngine;

public class PlayerShootingSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerShootingProvider>() == false) return;

        var playerShootingComponent = Providers.Get<PlayerShootingProvider>().component;

        if (CheckKey(playerShootingComponent))
        {
            Shoot(playerShootingComponent);
        }
    }

    private bool CheckKey(PlayerShootingComponent component)
    {
        var key = component.KeyShoot;

        if (Input.GetKeyDown(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Shoot(PlayerShootingComponent component)
    {
        var damage = component.Damage;
        var speed = component.Speed;
        var bulletPrefab = component.Bullet;
        var position = component.SpawnPosition.transform.position;
        var rotation = component.SpawnPosition.transform.rotation;
        var lifeTime = component.bulletLifeTime;

        Bullet bullet = GameObject.Instantiate(bulletPrefab.gameObject, position, rotation).GetComponent<Bullet>();

        MonoBehaviour.Destroy(bullet.gameObject, lifeTime);

        if (bullet.Providers.TryGet(out BulletProvider bulletProvider))
        {
            bulletProvider.component.Damage = damage;
        }

        if (bullet.Providers.TryGet(out MoveProvider moveProvider))
        {
            moveProvider.component.Speed = speed;
        }
    }
}
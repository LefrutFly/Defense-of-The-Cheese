using UnityEngine;

[System.Serializable]
public class PlayerShootingComponent
{
    public KeyCode KeyShoot;
    public float Damage;
    public float Speed;
    public Bullet Bullet;
    public GameObject SpawnPosition;
    public float bulletLifeTime;
}
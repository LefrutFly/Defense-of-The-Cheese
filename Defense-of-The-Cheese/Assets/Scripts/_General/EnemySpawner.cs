using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Entity enemyPrefab;
    [SerializeField] private int numberEnemiesInOneWave;
    [SerializeField] private float timeoutBetweenWave;
    [SerializeField] private float boxRange;
    [SerializeField] private float distanceToTower;

    [Inject] private Player player;
    [Inject] private Tower tower;
    [Inject] public Statistics Statistics;

    private List<Entity> enemies = new List<Entity>();
    private Coroutine spawner;
    private bool isLaunching = false;

    public void StopSpawn()
    {
        if (spawner != null)
        {
            StopCoroutine(spawner);
            spawner = null;
        }
    }

    public void LaunchSpawn()
    {
        if (spawner == null)
        {
            spawner = StartCoroutine(SpawnWaves());
        }
    }

    public void DeleteAllEnemies()
    {
        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            InstantiateWave();

            yield return new WaitForSeconds(timeoutBetweenWave);
        }
    }

    private void InstantiateWave()
    {
        for (int i = 0; i < numberEnemiesInOneWave; i++)
        {
            Entity entity = Instantiate
                (
                enemyPrefab.gameObject,
                GenerateRandomposition(),
                Quaternion.identity
                ).
                GetComponent<Entity>();

            if (entity.Providers.TryGet(out EnemyProvider enemyProvider))
            {
                enemyProvider.component.Player = player;
                enemyProvider.component.Tower = tower;
                enemyProvider.component.distanceToTowerForVision = distanceToTower;
            }

            if (entity is Enemy)
            {
                (entity as Enemy).Statistics = Statistics;
            }

            enemies.Add(entity);
        }
    }

    private Vector2 GenerateRandomposition()
    {
        float x = 0;
        float y = 0;

        int randSide = Random.Range(0, 4);
        if (randSide == 0)
        {
            x = Random.Range(-boxRange, boxRange);
            y = boxRange;
        }
        if (randSide == 1)
        {
            x = boxRange;
            y = Random.Range(-boxRange, boxRange);
        }
        if (randSide == 2)
        {
            x = Random.Range(-boxRange, boxRange);
            y = -boxRange;
        }
        if (randSide == 3)
        {
            x = -boxRange;
            y = Random.Range(-boxRange, boxRange);
        }

        return new Vector2(x, y);
    }
}

using System.Collections;
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

    private void Awake()
    {
        StartCoroutine(SpawnWaves());
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
        for(int i = 0; i < numberEnemiesInOneWave; i++)
        {
            Entity entity = Instantiate
                (
                enemyPrefab.gameObject, 
                GenerateRandomposition(), 
                Quaternion.identity
                ).
                GetComponent<Entity>();

            if(entity.Providers.TryGet(out EnemyProvider enemyProvider))
            {
                enemyProvider.component.Player = player;
                enemyProvider.component.Tower = tower;
                enemyProvider.component.distanceToTowerForVision = distanceToTower;
            }
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

using System.Collections;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Entity enemyPrefab;
    [SerializeField] private int numberEnemiesInOneWave;
    [SerializeField] private float timeoutBetweenWave;
    [SerializeField] protected float boxRange;

    [Inject] private Player player;

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
            }
        }
    }

    private Vector2 GenerateRandomposition()
    {
        return new Vector2(Random.Range(-boxRange, boxRange), Random.Range(-boxRange, boxRange));
    }
}

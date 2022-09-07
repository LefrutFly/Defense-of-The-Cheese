using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject[] prefabsForSpawn;
    [SerializeField] private int count;
    [SerializeField] private float width;
    [SerializeField] private float height;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            for(int i = 0; i < count; i++)
            {
                int randomPrefab = Random.Range(0, prefabsForSpawn.Length);
                GameObject prefab = prefabsForSpawn[randomPrefab];

                float x = Random.Range(-width, width);
                float y = Random.Range(-height, height);

                var obj = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);

                obj.transform.parent = transform;
            }

            yield return new WaitForSeconds(spawnTimer);
        }
    }
}

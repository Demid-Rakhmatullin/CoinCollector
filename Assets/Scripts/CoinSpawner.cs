using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject Type1Prefab;
    [SerializeField] GameObject Type2Prefab;
    [SerializeField] GameObject Type3Prefab;

    private int spawnedCounter;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (spawnedCounter <= 30)
            {
                var type = (CoinType)Random.Range(0, 3);
                GameObject prefab = null;

                switch (type)
                {
                    case CoinType.Type1:
                        prefab = Type1Prefab;
                        break;
                    case CoinType.Type2:
                        prefab = Type2Prefab;
                        break;
                    case CoinType.Type3:
                        prefab = Type3Prefab;
                        break;
                }

                var go = ObjectPool.Spawn(prefab, new Vector3(Random.Range(-15f, 15f), 1.5f, Random.Range(-15f, 15f)));
                var coin = go.GetComponent<Coin>();
                coin.SetSpawner(this);

                spawnedCounter++;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void Recycle(GameObject coin)
    {
        ObjectPool.Recycle(coin);
        spawnedCounter--;
    }
}

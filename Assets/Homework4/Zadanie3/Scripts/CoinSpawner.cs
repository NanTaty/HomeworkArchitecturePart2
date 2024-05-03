using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    private const float CycleDelay = 0.3f;
    private const float SpawnRadius = 0.5f;
    
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private float spawnTime;
    

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(spawnTime);
        WaitForSeconds cycleDelay = new WaitForSeconds(CycleDelay);
        while (true)
        {
            Vector3 randomSpawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Count)].position;

            if (HasAnyCoinOnPos(randomSpawnPosition))
            {
                yield return cycleDelay;
                continue;
            }

            Instantiate(_coin, randomSpawnPosition, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    private bool HasAnyCoinOnPos(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, SpawnRadius);
        
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Coin coin))
            {
                return true;
            }
        }

        return false;
    }

}
    

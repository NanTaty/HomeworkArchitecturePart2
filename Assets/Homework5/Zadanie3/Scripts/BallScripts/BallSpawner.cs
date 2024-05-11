using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour, IBallSpawner
{
    [SerializeField] private BallFactory ballFactory;

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField, Range(1, 20)] private int ballsToSpawn;

    public event Action OnFinishedSpawn;
    public event Action<Ball> OnBallSpawned;

    private void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < ballsToSpawn; i++)
        {
            BallType ballType = (BallType)Random.Range(0, Enum.GetValues(typeof(BallType)).Length);
            Ball ball = ballFactory.Get(ballType);
            ball.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            OnBallSpawned?.Invoke(ball);
            yield return new WaitForSeconds(0.2f);
        }
        
        OnFinishedSpawn?.Invoke();
    }

    
}

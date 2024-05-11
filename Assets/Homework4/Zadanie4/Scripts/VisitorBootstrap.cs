using UnityEngine;

namespace Assets.Visitor
{
    public class VisitorBootstrap : MonoBehaviour
    {
        [SerializeField] private Spawner _enemySpawner;
        [SerializeField] private SpawnerWeightConfig _spawnerWeightConfig;

        private Score _score;

        private void Awake()
        {
            _score = new Score(_enemySpawner);
            _enemySpawner.Init(_spawnerWeightConfig);
            _enemySpawner.StartWork();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                _enemySpawner.KillRandomEnemy();
        }
    }
}

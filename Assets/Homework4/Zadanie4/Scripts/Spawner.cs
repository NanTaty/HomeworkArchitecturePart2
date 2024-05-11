using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;
        
        public event Action<Enemy> Notified;

        private AddWeightVisitor _addWeightVisitor;

        public void Init(SpawnerWeightConfig spawnerWeightConfig)
        {
            _addWeightVisitor = new AddWeightVisitor(spawnerWeightConfig);
        }

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (!_addWeightVisitor.IsFull)
                {
                    Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                    enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                    enemy.Died += OnEnemyDied;
                    enemy.Accept(_addWeightVisitor);
                    _spawnedEnemies.Add(enemy);
                }
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
        
        private class AddWeightVisitor : IEnemyVisitor
        {
            private int _spawnWeight;
            private readonly SpawnerWeightConfig _spawnerWeightConfig;

            public bool IsFull => _spawnWeight >= _spawnerWeightConfig.MaxWeight;

            public AddWeightVisitor(SpawnerWeightConfig spawnerWeightConfig)
            {
                _spawnerWeightConfig = spawnerWeightConfig;
            }
            
            public void Visit(Elf elf)
            {
                _spawnWeight += _spawnerWeightConfig.ElfWeight;
                DecreaseOnDeath(elf, _spawnerWeightConfig.ElfWeight);
            }

            public void Visit(Human human)
            {
                _spawnWeight += _spawnerWeightConfig.HumanWeight;
                DecreaseOnDeath(human, _spawnerWeightConfig.HumanWeight);
            }

            public void Visit(Ork ork)
            {
                _spawnWeight += _spawnerWeightConfig.OrcWeight;
                DecreaseOnDeath(ork, _spawnerWeightConfig.OrcWeight);
            }

            public void Visit(Robot robot)
            {
                _spawnWeight += _spawnerWeightConfig.RobotWeight;
                DecreaseOnDeath(robot, _spawnerWeightConfig.RobotWeight);
            }

            private void DecreaseOnDeath(Enemy enemy, int amount)
            {
                Action<Enemy> OnDied = null;
                OnDied = (Enemy enemy) =>
                {
                    _spawnWeight -= amount;
                    enemy.Died -= OnDied;
                    OnDied = null;
                };
                enemy.Died += OnDied;
            }
        }
    }
}

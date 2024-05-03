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

        private int SpawnWeightValue
        {
            get => _addWeightVisitor.SpawnWeight;
            set => _addWeightVisitor.SpawnWeight = value;
        }

        public void StartWork()
        {
            StopWork();
            
            _addWeightVisitor = new AddWeightVisitor();

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
            WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
            while (true)
            {
                if (SpawnWeightValue >= 100)
                {
                    yield return waitForSeconds;
                    continue;
                }
                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                enemy.Accept(_addWeightVisitor);
                Debug.Log("Current spawn weight: " + SpawnWeightValue);
                _spawnedEnemies.Add(enemy);
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            SpawnWeightValue -= enemy.SpawnWeight;
            _spawnedEnemies.Remove(enemy);
        }
        
        private class AddWeightVisitor : IEnemyVisitor
        {
            public int SpawnWeight { get; set; }
            public void Visit(Elf elf)
            {
                SpawnWeight += elf.SpawnWeight;
            }

            public void Visit(Human human)
            {
                SpawnWeight += human.SpawnWeight;
            }

            public void Visit(Ork ork)
            {
                SpawnWeight += ork.SpawnWeight;
            }

            public void Visit(Robot robot)
            {
                SpawnWeight += robot.SpawnWeight;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public abstract class Enemy: MonoBehaviour
    {
        [SerializeField] private int spawnWeight;

        public int SpawnWeight => spawnWeight;

        private void OnValidate()
        {
            if (spawnWeight < 0)
            {
                spawnWeight = 0;
            }
        }

        public event Action<Enemy> Died;

        //Какая то общая логика врага: передвижение, жизни и тп.

        public void MoveTo(Vector3 position) => transform.position = position;

        public abstract void Accept(IEnemyVisitor visitor);

        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

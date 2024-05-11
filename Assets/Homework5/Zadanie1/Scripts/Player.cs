using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IEnemyTarget
{
    private int _maxHealth;
    private int _health;

    public Vector3 Position => transform.position;

    [Inject]
    private void Construct(PlayerStatsConfig statsConfig)
    {
        _health = _maxHealth = statsConfig.MaxHealth;
        Debug.Log($"Player Health: {_health}");
    }

    public void TakeDamage(int damage)
    {
        
    }
}

using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _damage;


    public void TakeDamage(int damage)
    {
        if (_health > 0)
        {
            _health -= damage;
        }
        else
        {
            Die();
        }
    }

    public void Healing(int healthPoints)
    {
        _health += healthPoints;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    private void Die()
    {
        Destroy(_player);
    }
}

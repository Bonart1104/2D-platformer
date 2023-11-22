using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }

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


    private void Die()
    {
        Destroy(gameObject);
    }
}

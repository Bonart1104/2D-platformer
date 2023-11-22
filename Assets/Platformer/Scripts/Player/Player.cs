using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;


    public void TakeDamage(int damage)
    {
        if (_health >= 0)
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
       
    }
}

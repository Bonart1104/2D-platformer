using UnityEngine;

public class CollectionTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CherryItem>(out CherryItem cherryItem))
        {
            _player.Healing(cherryItem.HealthPoints);
            Destroy(collision.gameObject);
        }
    }
}
using UnityEngine;

public class CollectionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CherryItem>(out CherryItem cherryItem))
        {
            Destroy(collision.gameObject);
        }
    }
}
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CherryItem _item;

    private void Start()
    {
        Instantiate(_item, transform.position, Quaternion.identity);
    }
}
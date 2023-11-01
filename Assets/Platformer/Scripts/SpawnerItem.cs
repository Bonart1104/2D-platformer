using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _item;

    private void Start()
    {
        Instantiate(_item, transform.position, Quaternion.identity);
    }
}


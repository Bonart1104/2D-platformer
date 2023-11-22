using UnityEngine;

public class CherryItem : MonoBehaviour
{
    [SerializeField] private int _healthPoints;

    public int HealthPoints => _healthPoints;
}
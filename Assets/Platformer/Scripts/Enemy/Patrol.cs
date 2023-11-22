using Unity.VisualScripting;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private int _speed;
    [SerializeField] private int _detectionDistance;

    private Transform _player;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _player = GameObject.FindAnyObjectByType<Player>().transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) < _detectionDistance)
        {
            Attack();
        }
        else
        {
            Patrolling();
        }

    }

    private void Patrolling()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);


        if (transform.position == target.position)
        {
            _currentPoint++;
            transform.eulerAngles = new Vector2(0, 0);

            if (_currentPoint >= _points.Length)
            {
                transform.eulerAngles = new Vector2(0, -180);
                _currentPoint = 0;
            }
        }
    }

    private void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }

}

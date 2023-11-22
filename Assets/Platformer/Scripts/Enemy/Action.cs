using UnityEngine;

public class Action : MonoBehaviour
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
            Chace();
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

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        ChangeLookDirection(target);
    }

    private void Chace()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);

        ChangeLookDirection(_player);        
    }

    private void ChangeLookDirection(Transform target)
    {
        if (transform.position.x > target.position.x)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, -180);
        }
    }

}

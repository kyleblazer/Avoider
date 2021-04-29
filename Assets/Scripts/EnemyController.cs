using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Vector3 startPosition = new Vector3 (0f, 0f, 0f);
    public Vector3 endPosition = new Vector3(0f, 0f, 0f);
    public bool isAttackingPlayer = false;
    public float detectionRange = 2;
    public Vector3[] _waypoints;



    public GameObject _enemy;
 
    private int _waypointIndex;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _waypoints = new[] { startPosition, endPosition };
        // The first transform in a movement path prefab is always going to be the container's transform
        this._enemy.transform.position = startPosition;
    }

    private void Update()
    {
        FollowPlayer();
        if (isAttackingPlayer == false) {
            FollowPath();
            SetNextTargetWaypoint();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        }
    }

    private void FollowPlayer()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < detectionRange &&
            Mathf.Abs(transform.position.y - player.transform.position.y) < detectionRange)
        {
            isAttackingPlayer = true;
        }
    }

    private void FollowPath()
    {
            _targetPosition = _waypoints[_waypointIndex];
            var movementOnFrame = 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, movementOnFrame);
    }

    private void SetNextTargetWaypoint()
    {
        if (new Vector3(transform.position.x, transform.position.y, transform.position.z) == _targetPosition)
        {
            _waypointIndex++;
        }

        if (_waypointIndex == _waypoints.Length)
        {
            _waypointIndex = 0;
        }
    }
}
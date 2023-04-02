using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private float _stalkingSpeed = 4;

    [Header("Patrol")]
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _treshold = 1f;

    private int _currentPoint = 0;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;

    private static readonly int Movement = Animator.StringToHash("Move");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int StalkingKey = Animator.StringToHash("Stalking");
    private static readonly int DieKey = Animator.StringToHash("Die");

    private void Awake()
    {
        _animatorController = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public IEnumerator DoPatrol()
    {
        while (enabled)
        {
            if ((_targetPoints[_currentPoint].position - transform.position).magnitude < _treshold)
            {
                _currentPoint++;
                if (_currentPoint >= _targetPoints.Length)
                {
                    _currentPoint = 0;
                }
            }

            Vector3 direction = (_targetPoints[_currentPoint].position - transform.position).normalized;
            Move(direction);
            yield return null;
        }
    }

    public void Move(Vector2 moveDirection)
    {
        _rigidbody.velocity = new Vector2(_moveSpeed * moveDirection.x, _moveSpeed * moveDirection.y);

        if (moveDirection == Vector2.zero)
            _animatorController.SetTrigger(Idle);
        else
        {
            _animatorController.SetTrigger(Movement);

            _animatorController.SetFloat("Horizontal", moveDirection.x);
            _animatorController.SetFloat("Vertical", moveDirection.y);
        }
    }

    public void Stalking(Vector2 moveDirection)
    {
        _rigidbody.velocity = new Vector2(_stalkingSpeed * moveDirection.x, _stalkingSpeed * moveDirection.y);

        _animatorController.SetTrigger(StalkingKey);

        _animatorController.SetFloat("Horizontal", moveDirection.x);
        _animatorController.SetFloat("Vertical", moveDirection.y);
    }
}

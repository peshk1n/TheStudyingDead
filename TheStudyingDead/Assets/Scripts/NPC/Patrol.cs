using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterMover))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _treshold = 1f;
    [SerializeField] private bool _loop = true;
    [SerializeField] private UnityEvent _action;

    private int _currentPoint = 0;
    private CharacterMover _mover;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
    }

    private void Update()
    {
        if ((_targetPoints[_currentPoint].position - transform.position).magnitude < _treshold)
        {
            _currentPoint++;
            if (_currentPoint >= _targetPoints.Length)
            {
                if(_loop)
                    _currentPoint = 0;
                else
                {
                    _mover.Move(Vector3.zero);
                    _action?.Invoke();
                    enabled = false;
                    return;
                }
            }
        }

        Vector3 direction = (_targetPoints[_currentPoint].position - transform.position).normalized;
        _mover.Move(direction);
    }
}

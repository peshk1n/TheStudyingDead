using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _treshold = 1f;

    private int _currentPoint = 0;
    private CharacterMover _mover;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
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
            _mover.Move(direction);
            yield return null;
        }
    }

/*    private void Update()
    {
        DoPatrol();
    }*/
}

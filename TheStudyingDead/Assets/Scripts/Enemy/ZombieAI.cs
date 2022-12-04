using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterMover))]
public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private LayerCheck _vision;
    [SerializeField] private LayerCheck _canAttack;
    [SerializeField] private float _attackCooldown = 0.5f;

    private Coroutine _current;
    private bool _isDead = false;

    private Patrol _patrol;
    private Animator _animator;
    private CharacterMover _mover;
    private ModifyHealthComponent _damageComponent;

    private void Start()
    {
        _patrol = GetComponent<Patrol>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<CharacterMover>();
        _damageComponent = GetComponent<ModifyHealthComponent>();

        StartState(Patrolling());
    }

    private void StartState(IEnumerator coroutine)
    {
        _mover.Move(Vector3.zero);

        if (_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(coroutine);
    }

    private IEnumerator Patrolling()
    {
        yield return _patrol.DoPatrol();
    }

    public void OnPlayerInVision()
    {
        if (_isDead)
            return;

        StartState(StalkingPlayer());
    }

    private IEnumerator StalkingPlayer()
    {
        while (_vision.IsTouchingLayer)
        {
            if (_canAttack.IsTouchingLayer)
            {
                StartCoroutine(Attack());
            }
            else
            {
                Vector3 direction = (_target.transform.position - transform.position).normalized;
                _mover.Move(direction);
            }
            yield return null;
        }

        StartState(Patrolling());
    }


    private IEnumerator Attack()
    {
        Debug.Log("Attack");
        _mover.Move(Vector3.zero);
        _damageComponent.Apply(_target.gameObject);
        yield return new WaitForSeconds(_attackCooldown);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduateStudentAI : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private LayerCheck _vision;
    [SerializeField] private LayerCheck _canAttack;
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private ZombieController _zombieController;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Coroutine _current;
    private bool _isDead = false;

    private ModifyHealthComponent _damageComponent;
    private Collider2D _collider;
    private bool _isAttacking = false;

    private void Awake()
    {
        _damageComponent = GetComponent<ModifyHealthComponent>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        if (_vision.IsTouchingLayer)
            StartState(StalkingPlayer());
        else
            StartState(Patrolling());
    }

    private void StartState(IEnumerator coroutine)
    {
        _rigidbody.velocity = Vector3.zero;

        if (_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(coroutine);
    }

    private IEnumerator Patrolling()
    {
        yield return _zombieController.DoPatrol();
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
                if (!_isAttacking)
                    _zombieController.Stalking(direction);
            }
            yield return null;
        }

        StartState(Patrolling());
    }

    public void DamagePlayer()
    {
        if(_canAttack.IsTouchingLayer)
            _damageComponent.Apply(_target.gameObject);
        _isAttacking = false;
    }

    private IEnumerator Attack()
    {
        _rigidbody.velocity = Vector2.zero;
        _isAttacking = true;
        Vector3 direction = (_target.transform.position - transform.position).normalized;

        _zombieController.Attack(direction);
        yield return new WaitForSeconds(_attackCooldown);
    }

    public void Die()
    {
        _rigidbody.velocity = Vector2.zero;
        _collider.enabled = false;
        _zombieController.Die();
        _isDead = true;

        if (_current != null)
            StopCoroutine(_current);
    }
}

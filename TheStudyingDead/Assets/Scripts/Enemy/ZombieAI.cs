using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private LayerCheck _vision;
    [SerializeField] private LayerCheck _canAttack;
    [SerializeField] private float _attackCooldown = 0.5f;
    [SerializeField] private ZombieController _zombieController;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _pushForce = 1;

    private Coroutine _current;
    private bool _isDead = false;

    private Animator _animator;
    private ModifyHealthComponent _damageComponent;
    private HealthComponent _hp;
    private Collider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _damageComponent = GetComponent<ModifyHealthComponent>();
        _hp = GetComponent<HealthComponent>();
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
        Debug.Log("Patrolling");
        yield return _zombieController.DoPatrol();
    }

    public void OnPlayerInVision()
    {
        if (_isDead)
            return;

        Debug.Log("OnPlayerInVision");

        StartState(StalkingPlayer());
    }

    private IEnumerator StalkingPlayer()
    {
        while (_vision.IsTouchingLayer)
        {
            Debug.Log("Stalking player");
            if (_canAttack.IsTouchingLayer)
            {
                StartCoroutine(Attack());
            }
            else
            {
                Vector3 direction = (_target.transform.position - transform.position).normalized;
                _zombieController.Stalking(direction);
            }
            yield return null;
        }

        StartState(Patrolling());
    }

    public void DamagePlayer()
    {
        _damageComponent.Apply(_target.gameObject);
    }

    private IEnumerator Attack()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * 3);

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

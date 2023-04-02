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

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _damageComponent = GetComponent<ModifyHealthComponent>();
        _hp = GetComponent<HealthComponent>();
        _collider = GetComponent<Collider2D>();

        StartState(Patrolling());
    }

    private void StartState(IEnumerator coroutine)
    {
        _zombieController.Move(Vector2.zero);

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
                _zombieController.Stalking(direction);
            }
            yield return null;
        }

        StartState(Patrolling());
    }


    private IEnumerator Attack()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * 3);

        _animator.SetTrigger("Attack");
        _damageComponent.Apply(_target.gameObject);
        yield return new WaitForSeconds(_attackCooldown);
    }

    public void Discard()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        _rigidbody.AddForceAtPosition(-1 * direction * _pushForce, _target.transform.position, ForceMode2D.Impulse);
        _hp.ModifyHealth(_hp.MaxHealth);

        Debug.Log("Zombie died");
    }

    public void Die()
    {
        _rigidbody.velocity = Vector2.zero;
        _collider.enabled = false;
        _animator.SetTrigger("Die");
        _isDead = true;

        if (_current != null)
            StopCoroutine(_current);
    }
}

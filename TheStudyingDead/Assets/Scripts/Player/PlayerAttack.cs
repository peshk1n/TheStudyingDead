using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _attackLayer;
    [SerializeField] private int _damage;

    private Collider2D[] _attackResult = new Collider2D[1];

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1f, 0, 0.1f);
        Gizmos.DrawSphere(_attackPosition.position, _attackRadius);
    }

    public void Attack()
    {
        int size = Physics2D.OverlapCircleNonAlloc(_attackPosition.position,
            _attackRadius, _attackResult, _attackLayer);

        for (int i = 0; i < size; ++i)
        {
            if (_attackResult[i].TryGetComponent<HealthComponent>(out HealthComponent hp))
            {
                hp.ModifyHealth(_damage * -1);
            }
        }
    }
}

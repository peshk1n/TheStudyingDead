using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _moneyStart;
    [SerializeField] private UnityEvent _onDamage;
    [SerializeField] private UnityEvent _onHeal;
    [SerializeField] private UnityEvent _onDeath;

    private int _health;
    private int _money;

    public int MaxHealth => _maxHealth;
    public int CurHealth => _health;

    public int Money => _money;

    private void Awake()
    {
        _health = _maxHealth-4;
        _money = _moneyStart;
    }

    public void ModifyHealth(int healthDelta)
    {
        _health += healthDelta;

        if (healthDelta < 0)
        {
            _onDamage?.Invoke();
        }
        else
        {
            _onHeal?.Invoke();
        }

        if (_health <= 0)
        {
            _onDeath?.Invoke();
        }
    }

    public void GetMoney(int coins)
    {
        _money += coins;
    }

    public void SpendMoney(int coins)
    {
        if (_money>=coins) _money -= coins;
    }
}

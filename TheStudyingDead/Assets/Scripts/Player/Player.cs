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

    public int MoneyStart => _moneyStart;

    private void Awake()
    {
        if (GameObjControl.Instance == null)
        {
            _money = _moneyStart;
            _health = _maxHealth;
        }
        else
        {
            _money = GameObjControl.Instance.money;
            _health = GameObjControl.Instance.health;
            Inventory _inv = FindObjectOfType<Inventory>();
            foreach (InventorySlot x in GameObjControl.Instance.inventory)
            {
                _inv.AddItems(x.item, x.amount);
            }
        }

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
            if(_health > _maxHealth)
                _health = _maxHealth;

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

    public bool SpendMoney(int coins)
    {
        if (_money >= coins)
        {
            _money -= coins; return true;
        }
        else return false;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
}

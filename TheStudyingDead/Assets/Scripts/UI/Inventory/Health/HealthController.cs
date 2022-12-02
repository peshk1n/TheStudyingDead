using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        var maxHealth = _player.MaxHealth;
        var value = (float)(_player.CurHealth / maxHealth);
        _healthBar.SetProgress(value);
    }
}

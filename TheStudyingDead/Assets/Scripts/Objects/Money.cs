using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Money : MonoBehaviour
{
    [SerializeField] int _sum;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    public void Add()
    {
        _player.GetMoney(_sum);
        Destroy(gameObject);
    }
}

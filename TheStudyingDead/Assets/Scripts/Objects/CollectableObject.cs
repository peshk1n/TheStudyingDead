using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    public void Add()
    {
        var inventory = _player.GetComponent<Inventory>();
        if (inventory)
        {
            inventory.AddItems(item, amount);
            Destroy(gameObject);
        }
    }
}

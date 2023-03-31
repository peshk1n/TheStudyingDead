using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] BoardWindow _tooltip;
    [SerializeField] private int _price;
    [SerializeField] private Item _item;
    
    private Player player;
    private Inventory inventory;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
    }
    public void Buy()
    {
        if (player.SpendMoney(_price)) inventory.AddItems(_item);
        else _tooltip.ShowMessage();
    }

    public void Open()
    {
        _tooltip.OpenShop();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_tooltip.isOpenShop) _tooltip.OpenShop();
        }
    }
}

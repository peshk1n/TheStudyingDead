using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> items = new List<InventorySlot>();

    [SerializeField] public UnityEvent OnInventoryChanged;

    public List<InventorySlot> GetListInventory => items;

    public void AddItems(Item item, int amount = 1)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item.id == item.id)
            {
                slot.amount += amount;
                OnInventoryChanged.Invoke();
                return;
            }
        }

        var new_slot = new InventorySlot(item);
        new_slot.amount += amount;
        items.Add(new_slot);
        OnInventoryChanged.Invoke();
    }

    public void DeleteItem(Item item, int amount = 1)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item.id == item.id)
            {
                slot.amount -= amount;
                OnInventoryChanged.Invoke();
                return;
            }
        }
    }

    public bool Contain(Item item)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item == item)
            {
                return true;
            }
        }
        return false;
    }

    public bool ContainId(string id)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item.id == id)
            {
                return true;
            }
        }
        return false;
    }

    public Item GetItem(int i)
    {
        return i < items.Count ? items[i].item : null;
    }

    public int GetAmount(int i)
    {
        return i < items.Count ? items[i].amount : 0;

    }

    public int GetSize()
    {
        return items.Count;
    }
}

[Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;

    public InventorySlot(Item item)
    {
        this.item = item;
    }
}
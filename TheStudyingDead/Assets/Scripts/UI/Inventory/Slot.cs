using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int ind;
    [SerializeField] InventoryUI _inventoryUI;
    private List<Button> buttons;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        buttons=_inventoryUI.Buttons;
    }
    public void UseSlot()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i == ind)
            {
                if (_inventory.GetItem(i)!=null&&!_inventory.GetItem(i).isQuestItem && _inventory.GetAmount(i) > 0)
                {
                    if (_inventory.GetItem(i) as FoodItem)
                    {
                        var item = (FoodItem)_inventory.GetItem(i);
                        player.ModifyHealth((int)item.healthImprov);
                        _inventory.DeleteItem(_inventory.GetItem(i));
                    }
                    if (_inventory.GetItem(i) as WeaponItem)
                    {
                        var item = (WeaponItem)_inventory.GetItem(i);
                        if (!player.GetComponent<PlayerController>().IsArmed) 
                            player.GetComponent<PlayerController>().ArmPlayer();
                        else player.GetComponent<PlayerController>().DisarmPlayer();
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private List<TMP_Text> amounts = new List<TMP_Text>();
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private Inventory _inventory;
    private Player player;

    private void Start()
    {
        player=FindObjectOfType<Player>();
    }

    public void UpdateUI(Inventory inventory)
    {
        for (int i = 0; i < inventory.GetSize() && i < icons.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 1);
            icons[i].sprite = inventory.GetItem(i).icon;
            
            amounts[i].text = inventory.GetAmount(i)>0? "x"+inventory.GetAmount(i).ToString(): "";
        }

        for (int i=inventory.GetSize();i<icons.Count;i++)
        {
            icons[i].color=new Color(1,1,1,0);
            icons[i].sprite = null;

            amounts[i].text = "";
        }
    }

    public void UseSlot()
    {
        for (int i = 0; i < _inventory.GetSize() && i < buttons.Count; i++)
        {
            if (_inventory.GetItem(i) is FoodItem)
            {
                var item=(FoodItem)_inventory.GetItem(i);
                player.ModifyHealth((int)item.healthImprov);
                _inventory.DeleteItem(_inventory.GetItem(i));
                icons[i].color = new Color(1, 1, 1, 0);
                icons[i].sprite = null;
            }
                
        }
    }
    
}

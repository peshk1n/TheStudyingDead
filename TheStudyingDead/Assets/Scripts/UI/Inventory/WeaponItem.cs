using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItem", menuName = "Inventory/Item/New Weapon Item")]
public class WeaponItem : Item
{
    public double damage;
    private bool use=false;
    public bool Use => use;
    public void Select()
    {
        use = !use;
    }
}

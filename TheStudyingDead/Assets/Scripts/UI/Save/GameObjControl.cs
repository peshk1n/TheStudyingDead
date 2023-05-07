using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjControl : MonoBehaviour
{
    public static GameObjControl Instance;
    public int money;
    public int health;
    public List<InventorySlot> inventory;
    void Awake()
    {
        //Player pl = FindObjectOfType<Player>();
        //money = pl.MoneyStart;
        //health = pl.MaxHealth;
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayer()
    {
        Player pl = FindObjectOfType<Player>();
        Inventory _inv = FindObjectOfType<Inventory>();
        GameObjControl.Instance.money = pl.Money;
        GameObjControl.Instance.health = pl.CurHealth;
        GameObjControl.Instance.inventory = _inv.GetListInventory;
        
    }
}

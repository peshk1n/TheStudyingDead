using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardWindow : MonoBehaviour
{
    [SerializeField] GameObject _this;
    [SerializeField] InventoryAnimatedWindow _inventoryAnimatedWindow;
    [SerializeField] MenuAnimatedWindow _menuAnimatedWindow;

    private void Start()
    {
        _this.SetActive(false);
    }

    public void Open()
    {
       if (!_inventoryAnimatedWindow.IsOpen&&!_menuAnimatedWindow.IsOpen) _this.SetActive(true);
    }

    public void Close()
    {
        _this.SetActive(false);
    }
}

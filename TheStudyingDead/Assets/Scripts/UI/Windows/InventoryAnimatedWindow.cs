using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimatedWindow : AnimatedWindow
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _tasks;
    
    private Canvas _inventoryCanvas;

    void Start()
    {
        _inventoryCanvas = GetComponent<Canvas>();
        _inventoryCanvas.enabled = false;
        
        _inventory.SetActive(false);
        _tasks.SetActive(false);
    }

    public void OpenNotebook()
    {
        _inventoryCanvas.enabled = !_inventoryCanvas.enabled;
        if (!_inventoryCanvas.enabled)
        {
            _tasks.SetActive(false);
            _inventory.SetActive(false);
        }
    }

    public void OnShowInventory()
    {   
        _tasks.SetActive(false);
        _inventory.SetActive(true);
    }

    public void OnShowTasks()
    {
        _inventory.SetActive(false);
        _tasks.SetActive(true);
    }
}

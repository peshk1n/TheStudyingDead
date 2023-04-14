using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimatedWindow : AnimatedWindow
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _tasks;
    
    private Canvas _inventoryCanvas;

    private bool _isOpen;
    public bool IsOpen { get { return _isOpen; } }

    void Start()
    {
        _inventoryCanvas = GetComponent<Canvas>();
        _inventoryCanvas.enabled = false;
        
        //_inventory.SetActive(false);
        _tasks.SetActive(false);

        _isOpen = false;
    }

    public void OpenNotebook()
    {
        _inventoryCanvas.enabled = !_inventoryCanvas.enabled;
        _isOpen = !_isOpen;
        if (!_inventoryCanvas.enabled)
        {
            _tasks.SetActive(false);
            _inventory.SetActive(true);
            // _inventory.SetActive(false);
            _isOpen = false;
        }
    }

    public void CloseNotebook()
    {
        _inventoryCanvas.enabled = false;
        _tasks.SetActive(false);
       // _inventory.SetActive(false);
        _isOpen = false;

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

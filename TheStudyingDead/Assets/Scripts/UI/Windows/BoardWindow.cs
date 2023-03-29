using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardWindow : MonoBehaviour
{
    [SerializeField] GameObject _this;
    [SerializeField] CanvasGroup _board;
    [SerializeField] CanvasGroup _shop;
    [SerializeField] InventoryAnimatedWindow _inventoryAnimatedWindow;
    [SerializeField] MenuAnimatedWindow _menuAnimatedWindow;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _this.SetActive(false);
        _shop.alpha = 0;
        _board.alpha = 0;
    }

    public void Open()
    {
        if (_this.active == false && !_inventoryAnimatedWindow.IsOpen && !_menuAnimatedWindow.IsOpen)
        {
            _this.SetActive(true);
        }
    }

    public void Close()
    {
        _this.SetActive(false);
        _shop.alpha = 0;
        _board.alpha = 0;
        CloseMessage();
    }

    public void OpenBoard()
    {
        Open();
        if (_board.alpha==1) _board.alpha=0;
        else _board.alpha=1;
    }

    public void OpenShop()
    {
        Open();
        if (_shop.alpha == 1) { _shop.alpha = 0; CloseMessage(); }
        else _shop.alpha = 1;
    }

    public void ShowMessage()
    {
        _text.alpha = 1;
    }
    public void CloseMessage()
    {
        _text.alpha = 0;
    }
}

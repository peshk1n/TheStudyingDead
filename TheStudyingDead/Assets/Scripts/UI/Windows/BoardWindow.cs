using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BoardWindow : MonoBehaviour
{
    //[SerializeField] GameObject _this;
    [SerializeField] CanvasGroup _board;
    [SerializeField] CanvasGroup _shop;
    //[SerializeField] InventoryAnimatedWindow _inventoryAnimatedWindow;
    //[SerializeField] MenuAnimatedWindow _menuAnimatedWindow;

    private GameObject _this;
    private InventoryAnimatedWindow _inventoryAnimatedWindow;
    private MenuAnimatedWindow _menuAnimatedWindow;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private GameObject exp;

    private bool _isOpenShop;
    private bool _isOpenBoard;
    public bool isOpenBoard => _isOpenBoard;
    public bool isOpenShop => _isOpenShop;

    private void Start()
    {
        _inventoryAnimatedWindow =GameObject.Find("InventoryCanvas").GetComponent<InventoryAnimatedWindow>();
        _menuAnimatedWindow= GameObject.Find("MenuPanel").GetComponent<MenuAnimatedWindow>();
        _this= GameObject.Find("CanvasBoard");
        _this.SetActive(false);
        _shop.alpha = 0;
        _board.alpha = 0;

        _isOpenShop = false;
        _isOpenBoard = false;
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
        _isOpenShop = false;
        _isOpenBoard = false;
        CloseMessage();
    }

    public void OpenBoard()
    {
        Open();
        _isOpenBoard=!_isOpenBoard;
        if (_board.alpha == 1)
        {
            _board.alpha = 0;
            Close();
            if (exp != null) exp.SetActive(true);
        }
        else _board.alpha = 1;
    }

    public void OpenShop()
    {
        Open();
        _isOpenShop = !_isOpenShop;
        if (_shop.alpha == 1) { _shop.alpha = 0; Close(); CloseMessage(); }
        else
        {
            _shop.alpha = 1;
        }
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

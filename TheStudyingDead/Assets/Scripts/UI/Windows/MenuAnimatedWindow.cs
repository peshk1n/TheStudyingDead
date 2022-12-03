using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimatedWindow : AnimatedWindow
{
    private Canvas _menuCanvas;

    void Start()
    {
        _menuCanvas = GetComponent<Canvas>();
        _menuCanvas.enabled = false;
    }

    public void OpenMenu()
    {
        _menuCanvas.enabled = !_menuCanvas.enabled;
    }
}

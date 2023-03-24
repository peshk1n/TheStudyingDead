using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callboard : MonoBehaviour
{
    [SerializeField] CanvasGroup _tooltip;

    public void Open()
    {
        _tooltip.alpha = 1;
    }

    public void Close()
    {
        _tooltip.alpha = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callboard : MonoBehaviour
{
    [SerializeField] BoardWindow _tooltip;

    public void Open()
    {
        _tooltip.Open();
    }

    public void Close()
    {
        _tooltip.Close();
    }
}

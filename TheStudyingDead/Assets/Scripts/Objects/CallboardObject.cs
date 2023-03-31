using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallboardObject : MonoBehaviour
{
    [SerializeField] BoardWindow _tooltip;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_tooltip.isOpenBoard) _tooltip.OpenBoard();
        }
    }
}

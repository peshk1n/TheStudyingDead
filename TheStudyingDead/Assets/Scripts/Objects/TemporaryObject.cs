using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryObject : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _action.Invoke();
            if (gameObject!=null) Destroy(gameObject);
            
        }
    }
}

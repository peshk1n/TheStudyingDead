using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    [SerializeField] private Dialogue _bound;
    [SerializeField] private Mode _mode;
    [SerializeField] private DialogDef _external;
   

    private DialogManager _manager;

    public enum Mode
    {
        Bound, External
    }

    public Dialogue Dialogue
    {
        get
        {
            switch (_mode)
            {
                case Mode.Bound:
                    return _bound;
                case Mode.External:
                    return _external.Dialogue;
                default:
                    throw new System.ArgumentOutOfRangeException();

            }

        }
    }
    public void TriggerDialogue()
    {
        if (_manager == null)
            _manager = FindObjectOfType<DialogManager>();
        _manager.StartDialogue(Dialogue,_action);



    }
    public void TriggerDialogue(DialogDef def)
    {
        _external = def;
        TriggerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<DialogManager>().StartDialogue(Dialogue,_action);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<DialogManager>().EndDialogue();

    }
    
    public void DeleteObject()
    {
        Destroy(gameObject);
    }

    public void DeleteDialogue()
    {
        Destroy(gameObject.GetComponent<DialogTrigger>());
    }

}


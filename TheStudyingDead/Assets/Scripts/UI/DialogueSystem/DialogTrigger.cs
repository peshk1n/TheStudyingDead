using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
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
        _manager.StartDialogue(Dialogue);

    }
    public void TriggerDialogue(DialogDef def)
    {
        _external = def;
        TriggerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<DialogManager>().StartDialogue(Dialogue);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<DialogManager>().EndDialogue();

    }
}


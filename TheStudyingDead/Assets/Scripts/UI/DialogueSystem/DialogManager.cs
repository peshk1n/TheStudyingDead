using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TMP_Text/*TextMeshProUGUI*/ nameText;
    public TMP_Text/*TextMeshProUGUI*/ dialogText;
    public Animator animator;

    private Queue<string> _sentences;
    private Queue<string> _name;

    private UnityEvent _action;
    void Start()
    {
        _sentences = new Queue<string>();
        _name = new Queue<string>();
    }
    private void Update()
    {
        if (animator.GetBool("IsOpen") && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)))
            ShowNextSentences();
    }
    public void StartDialogue(Dialogue dialogue, UnityEvent action) 
    {
        _action = action;
        GameObject.Find("CanvasDialogue").GetComponent<CanvasGroup>().alpha = 1f;
        animator.SetBool("IsOpen", true);
        _sentences.Clear();
        _name.Clear();
        foreach (string x in dialogue.sentences) 
        {
            _sentences.Enqueue(x);
        }
        foreach (string x in dialogue.name)
        {
            _name.Enqueue(x);
        }

        ShowNextSentences();
    }

    public void ShowNextSentences() 
    {
        
        if (_sentences.Count == 0) 
        {
            EndDialogue();
            _action.Invoke();
            return;
        }
        string sent = _sentences.Dequeue();
        string name = _name.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sent, name));

    }

    IEnumerator TypeSentence(string sentence_, string name_)
    {
        dialogText.text = "";
        nameText.text = name_;
        foreach(char x in sentence_.ToCharArray())
        {
            dialogText.text += x;
            for(int i = 0; i <= 1;i++)
            {
                yield return null;
            }
            
        }

    }

    public void EndDialogue() 
    {
        animator.SetBool("IsOpen", false);
    }

    //[SerializeField] private Dialogue _testD;
    //public void Test()
    //{
    //    StartDialogue(_testD);
    //}

}

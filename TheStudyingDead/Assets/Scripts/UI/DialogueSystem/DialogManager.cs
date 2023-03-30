using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Animator animator;

    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();   
    }

    public void StartDialogue(Dialogue dialogue) 
    {
        GameObject.Find("CanvasDialogue").GetComponent<CanvasGroup>().alpha = 1f;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string x in dialogue.sentences) 
        {
            sentences.Enqueue(x);
        }

        ShowNextSentences();
    }

    public void ShowNextSentences() 
    {
        
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }
        string sent = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sent));

    }

    IEnumerator TypeSentence(string sentence) 
    {
        dialogText.text = "";
        foreach(char x in sentence.ToCharArray())
        {
            dialogText.text += x;
            for(int i = 0; i <= 2;i++)
            {
                yield return null;
            }
            
        }

    }

    public void EndDialogue() 
    {
        animator.SetBool("IsOpen", false);
    }

    [SerializeField] private Dialogue _testD;
    public void Test()
    {
        StartDialogue(_testD);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxConntroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _container;
    [SerializeField] private Animator _animator;

    [Space][SerializeField] private float _textSpeed = 0.09f;

    [Header("Sounds")][SerializeField] private AudioClip _typing;
    [SerializeField] private AudioClip _open;
    [SerializeField] private AudioClip _close;

    private static readonly int IsOpen = Animator.StringToHash("IsOpen");
    private DialogData _data;
    private int _currentSentence;
    private AudioSource _aSource;
    private Coroutine _typingRoutine;

    //private void Start()
    //{
    //    //_aSource = 
    //}
    public void ShowDialog(DialogData data)
    {
        _data = data;
        _currentSentence = 0;
        _text.text = string.Empty;

        _container.SetActive(true);
        _animator.SetBool(IsOpen, true);
    }
    private IEnumerator TypeDialogText()
    {
        _text.text = string.Empty;
        var sentence = _data.Sentences[_currentSentence];
        foreach(var x in sentence)
        { 
            _text.text += x;
            yield return new WaitForSeconds(_textSpeed);
        }
        _typingRoutine = null;
    }

    public void OnSkip()
    {
        if (_typingRoutine == null) return;
        StopTypeAnimation();
        _text.text = _data.Sentences[_currentSentence];
    }

    public void OnContinue()
    {
        StopTypeAnimation();
        _currentSentence++;
        if (_currentSentence >= _data.Sentences.Length)
        {
            HideDialogBox();
        }
        else 
        {
            OnStartDialogAnimation();
        }
    }

    private void HideDialogBox()
    {
        _animator.SetBool(IsOpen, false);
    }

    private void StopTypeAnimation()
    {
        if (_typingRoutine != null)
            StopCoroutine(_typingRoutine);
        _typingRoutine = null;
    }

    private void OnStartDialogAnimation()
    {
        _typingRoutine = StartCoroutine(TypeDialogText());
    }

    private void OnCloseAnimationComplete()
    {

    }

    [SerializeField] private DialogData _testData;
    public void Test()
    {
        ShowDialog(_testData);
    }


}
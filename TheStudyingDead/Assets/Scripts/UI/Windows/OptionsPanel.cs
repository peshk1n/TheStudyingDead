using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    private CanvasGroup _panel;
    private Animator _animator;
    private Action _closeAction;

    private bool _isOpen;
    public bool IsOpen { get { return _isOpen; } }

    private void Start()
    {
        _panel = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Normal");
    }

    public void Close()
    {
        _animator.SetTrigger("Close");
        _isOpen = false;
    }

    public void Open()
    {
        _animator.SetTrigger("Show");
        _isOpen = true;
    }
}

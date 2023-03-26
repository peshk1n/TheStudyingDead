using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAnimatedWindow : MonoBehaviour
{
    private CanvasGroup _panel;
    private Animator _animator;
    private Action _closeAction;

    private bool _isOpen;
    public bool IsOpen { get { return _isOpen; } }

    void Start()
    {
        _panel= GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("Normal");
        _isOpen = false;
    }

    public void Close()
    {
        _animator.SetTrigger("Close");
        Time.timeScale = 1;
        _isOpen = false;
    }

    public void OpenMenu()
    {
        if (_panel.alpha == 1)
        { Close(); Time.timeScale = 1; }
        else
        {
            _isOpen = true;
            _animator.SetTrigger("Show");
            Time.timeScale = 0;
        }
    }

    public void OnContinue()
    {
        Close();
    }

    public void OnStartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Close();
    }

    public void OnShowControl()
    {
        var _canvas = _panel.GetComponentInParent<Canvas>();
        var panel = Resources.Load<GameObject>("UI/ControlPanel");
        Instantiate(panel, _canvas.transform);
    }

    public void OnShowOptions()
    {
        var _canvas = _panel.GetComponentInParent<Canvas>();
        var panel = Resources.Load<GameObject>("UI/OptionsPanel");
        Instantiate(panel, _canvas.transform);
    }

    public void OnShowMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Close();
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnCloseAnimationComplete()
    {
        Destroy(gameObject);
        _closeAction?.Invoke();
    }
}

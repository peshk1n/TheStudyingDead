using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuWindow : AnimatedWindow
{
    private Action _closeAction;
    //[SerializeField]private CanvasGroup _settings;
    //public void OnShowSettings()
    //{
    //    if (_settings.gameObject.active) _settings.gameObject.SetActive(false);
    //    else _settings.gameObject.SetActive(true);
    //    //if (_settings.alpha == 0) _settings.alpha = 1;
    //    //else _settings.alpha =0;
    //    //var window = Resources.Load<GameObject>("UI/SettingsWindow");
    //    //var canvas = FindObjectOfType<Canvas>();
    //    //Instantiate(window, canvas.transform);
    //}
    public void OnContinue()
    {
        _closeAction = () => { SceneManager.LoadScene("SampleScene"); };
        Close();
    }

    public void OnStartNewGame()
    {
        _closeAction = () => { SceneManager.LoadScene("SampleScene"); };
        Close();
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public override void OnCloseAnimationComplete()
    {
        base.OnCloseAnimationComplete();
        _closeAction?.Invoke();
    }
}

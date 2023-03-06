using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : AnimatedWindow
{
    private Action _closeAction;

    public void OnShowSettings()
    {
        var window = Resources.Load<GameObject>("UI/SettingsWindow");
        var canvas = FindObjectOfType<Canvas>();
        Instantiate(window, canvas.transform);
    }
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

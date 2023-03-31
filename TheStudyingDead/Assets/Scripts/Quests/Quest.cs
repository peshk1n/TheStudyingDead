using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected string _description;
    private bool _isFinish=false;

    public bool IsFinish => _isFinish;
    public string Name => _name;
    public string Description => _description;

   
    public void StartQuest()
    {
        QuestManager manager = FindObjectOfType<QuestManager>();
        manager.StartMessage();
    }

    public void FinishQuest()
    {
        QuestManager manager = FindObjectOfType<QuestManager>();
        manager.FinishMessage();
        Invoke("wait", 2);
        gameObject.active = false;
        //Destroy(gameObject);
    }


    private void wait()
    {
        _isFinish = true;
    }

}

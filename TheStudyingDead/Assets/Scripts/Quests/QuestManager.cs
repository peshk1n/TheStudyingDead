using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private List<Quest> _quests;
    [SerializeField] private TMP_Text _message;

    private Quest _current;
    private int ind = 0;

    private void Start()
    {
        if (_quests != null)
            _current = _quests[ind];
    }

    private void Update()
    {
        if (_current.IsFinish)
        {
            ind++;
            if (ind < _quests.Count)
            {
                _current = _quests[ind];
            }
            //else Destroy(gameObject);
        }
    }

    
    public void FinishMessage()
    {
        _message.text = "Задание выполнено";
        Invoke("CloseMessage", 2);
        _name.text = "";
        _description.text = "";
    }

    private void CloseMessage()
    {
        _message.text = "";

    }
    public void StartMessage()
    {
        _message.text = "Получено новое задание\n\nПодробности в профиле";
        Invoke("CloseMessage", 3);
        _name.text = _current.Name;
        _description.text = _current.Description;
    }
}

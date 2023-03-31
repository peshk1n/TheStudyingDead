using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GiveQuest : MonoBehaviour
{
    [SerializeField] private Quest _quest;
    [SerializeField] private UnityEvent _action;

    [SerializeField] List<GameObject> _activeObjects;
    [SerializeField] List<Collider2D> _activeColliders;
    [SerializeField] List<GameObject> _offObjects;
    [SerializeField] List<Collider2D> _offColliders;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _action.Invoke();
        }
    }

    public void StartQuest()
    {
        QuestManager manager = FindObjectOfType<QuestManager>();
        manager.StartMessage();
    }

    public void ChangeAvailableObject()
    {
        foreach (GameObject obj in _activeObjects)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in _offObjects)
        {
            obj?.SetActive(false);
        }
        foreach (Collider2D collider in _activeColliders)
        {
            collider.enabled = true;
        }
        Destroy(gameObject);
    }
}

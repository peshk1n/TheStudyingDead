using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestObject : MonoBehaviour
{
    [SerializeField] private Quest _quest;
    [SerializeField] private UnityEvent _action;

    [SerializeField] List<GameObject> _activeObjects;
    [SerializeField] List<Collider2D> _activeColliders;
    [SerializeField] List<GameObject> _offObjects;
    [SerializeField] List<Collider2D> _offColliders;

    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _action.Invoke();
            
        }
    }

    public void StartQuest()
    {
       _quest.StartQuest();
        gameObject.active = false;
    }

    public void FinishQuest()
    {
        _quest.FinishQuest();
        gameObject.active = false;
    }

    public void AvailableObj()
    {
        foreach (GameObject obj in _activeObjects)
        {
            if (obj != null) obj.SetActive(true);
        }
        foreach (GameObject obj in _offObjects)
        {
            if (obj != null) obj?.SetActive(false);
        }
        foreach (Collider2D collider in _offColliders)
        {
            if (collider != null) collider.enabled = false;
        }
        foreach (Collider2D collider in _activeColliders)
        {
            if (collider != null) collider.enabled = true;
        }
    }

    public void ChangeAvailableObject()
    {
        Invoke("AvailableObj", 2);
        //Destroy(gameObject);
    }

    public bool CheckInventory(Item item)
    {
        if (_player.GetComponent<Inventory>().Contain(item))
            return true;
        else return false;
    }

    public void FinishIfHasItem(Item item)
    {
        if (CheckInventory(item))
        {
            _quest.FinishQuest();
            AvailableObj();
        }

    }
}

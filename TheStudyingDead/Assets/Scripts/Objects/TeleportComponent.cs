using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    [SerializeField] private Transform _destTransform;
    [SerializeField] private string _keyId;
    private Player _player;


    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void Teleport()
    {
        var player = GameObject.Find("Player");
        player.transform.position = _destTransform.position;
    }

    public void OpenClosedDoor()
    {
        var inventory = _player.GetComponent<Inventory>();
        if (inventory)
        {
            if (inventory.ContainId(_keyId))
                Teleport();
        }
    }
    
}

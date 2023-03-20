using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportComponent : MonoBehaviour
{
    [SerializeField] private Transform _destTransform;

    public void Teleport()
    {
        var player=GameObject.Find("Player");
        player.transform.position = _destTransform.position;
    }
}

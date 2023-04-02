using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    [SerializeField] List<GameObject> _activeObjects;

    public void Turn()
    {
        foreach (GameObject obj in _activeObjects)
        {
            if (obj != null) obj.SetActive(true);
        }
    }
}

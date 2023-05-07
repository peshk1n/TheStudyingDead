using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassTransformation : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] private GameObject[] _activeObjects;
    [SerializeField] private GameObject[] _offObjects;

    public void StartTransformation()
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].enabled = true;
            _animators[i].Play("Transformation");
        }
    }

    public void OffObjects()
    {
        for(int i = 0; i < _offObjects.Length; i++)
        {
            _offObjects[i]?.SetActive(false);
        }
    }

    public void EnableObjects()
    {
        for (int i = 0; i < _activeObjects.Length; i++)
        {
            _activeObjects[i]?.SetActive(true);
        }
    }

    public void AvailableObj()
    {
        OffObjects();
        EnableObjects();
    }
}

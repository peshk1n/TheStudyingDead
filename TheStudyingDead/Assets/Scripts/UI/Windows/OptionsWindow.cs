using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsWindow : MonoBehaviour
{

    [SerializeField] private GameObject _obj;

    private void Start()
    {
       // _obj = GetComponent<GameObject>();
        Close();
    }

    public void Open()
    {
        _obj.SetActive(true);
    }

    public void Close()
    {
        _obj?.SetActive(false);
    }
    
   
}

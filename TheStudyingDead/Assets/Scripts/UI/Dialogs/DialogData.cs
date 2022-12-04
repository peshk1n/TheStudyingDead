 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData : MonoBehaviour
{
    [SerializeField] private string[] _sentences;
    public string[] Sentences => _sentences;
}

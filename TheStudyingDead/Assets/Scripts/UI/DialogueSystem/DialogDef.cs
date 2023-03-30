using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Dialog", fileName = "Dialog")]
public class DialogDef : ScriptableObject
{
    
    [SerializeField] Dialogue _dialogue;
    public Dialogue Dialogue => _dialogue;
}

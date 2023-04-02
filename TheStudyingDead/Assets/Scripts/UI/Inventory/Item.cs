using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ItemType { Food, Weapon, Instrument}
public class Item : ScriptableObject
{
    public string id;
    public Sprite icon;
    public bool isQuestItem=false;
}

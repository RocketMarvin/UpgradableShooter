using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Shopmenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSD : ScriptableObject
{
    public string title;
    public string description;
    public int basecost;
}

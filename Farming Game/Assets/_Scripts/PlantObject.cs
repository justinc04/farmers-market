using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public int buyPrice;
    public int sellPrice;
    public float growthTime;
    public Sprite[] plantStages;
    public Sprite icon;
}

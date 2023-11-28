using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UpgradeTree : MonoBehaviour
{
    public string id;
    public bool isUnlocked;
    public int cost;
    public List<string> prerequisites;

    public Action effect;

    public UpgradeTree(string id, bool isUnlocked, int cost, List<string> prerequisites, Action effect)
    {
        this.id = id;
        this.isUnlocked = isUnlocked;
        this.cost = cost;
        this.prerequisites = prerequisites;
        this.effect = effect;
    }
    public void ApplyEffect()
    {
        if(isUnlocked)
        {
            effect?.Invoke();
        }
    }
}

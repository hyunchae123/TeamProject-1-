using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public readonly string ID;
    public string name;
    public Sprite icon;

    public Skill(string ID, string name, Sprite icon)
    {
        this.name = name;
        this.icon = icon;
        this.ID = ID;
    }
}

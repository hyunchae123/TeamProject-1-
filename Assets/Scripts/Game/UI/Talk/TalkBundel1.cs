using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Talk
{
    public string name;
    public string talk;
    public string spriteID;
}

[CreateAssetMenu]
public class TalkBundel1 : ScriptableObject
{
    public Talk[] talks;
}

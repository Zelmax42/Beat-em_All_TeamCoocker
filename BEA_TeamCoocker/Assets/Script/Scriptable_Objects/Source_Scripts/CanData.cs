using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;


[CreateAssetMenu(fileName = "NewCanData", menuName = "SO/Can Data", order = 1)]
public class CanData : ScriptableObject
{
    public enum CanType
    {
        Life,
        Energy
    }
    public CanType can;
    public float value;
}
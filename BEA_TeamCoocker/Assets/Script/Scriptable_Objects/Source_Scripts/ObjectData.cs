using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectData", menuName = "SO/ObjectData", order = 2)]
public class ObjectData : ScriptableObject
{
    public AnimationCurve myCurve;
    public AnimationCurve BonkCurve;
    public float bonkDistance;
    public float throwDistance;
    public float travelDuration;
    public enum ObjectType
    {
        Leger,
        Lourd
    }
    public ObjectType type ;
    public int usure;
    public float damage;
    public bool canDrop;
    public GameObject[] lootTable;

    public float _gravity;
    public float _mass;
  
}


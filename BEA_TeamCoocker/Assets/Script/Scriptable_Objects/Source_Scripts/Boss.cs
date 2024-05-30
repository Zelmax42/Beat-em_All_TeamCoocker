using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossSO", menuName = "SO/Boss", order = 4)]

public class Boss : ScriptableObject
{
    public float bossHP;
    public float dashDamage;
    public float laserDamage;
    public float moveSpeed;
    public float dashSpeed;
}

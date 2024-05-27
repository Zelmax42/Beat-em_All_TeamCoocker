using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "P",menuName = "SO/Player", order = 0)]
public class Player : ScriptableObject
{
    public float pvPlayer = 5f;
    public float dmgPlayer = 1f;
    public float staminaPlayer = 5f;
    public float speedPlayer = 5f;
    public float jumpStrengthPlayer = 5f;
    public int comboPlayer = 5;
    public int punchComboPLayer = 5;
    public bool isGrabing = false;
    public bool isGrounded = false;

    public States currentStates = States.IDLE;
    public enum States
    {
        IDLE, WALK, PUNCH, JUMP, GRAB, HURT, FALL, ULTIMATE, DEAD
    }
}

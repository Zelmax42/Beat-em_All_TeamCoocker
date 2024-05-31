using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Player _player;
    public float _PlayerHP = 50;

    // Start is called before the first frame update
    void Start()
    {
        _player.pvPlayer = 50;
        _player.currentStates = Player.States.IDLE;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject hurtbox;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        hurtbox.SetActive(true);
    }

    public void Deactivate()
    {
        hurtbox.SetActive(false);
    }
}

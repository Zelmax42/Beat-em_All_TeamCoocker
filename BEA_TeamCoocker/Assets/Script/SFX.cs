using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource punch_1;
    public AudioSource punch_2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SFXPunch(int punch)
    {
        if (punch == 1 )
        {
            punch_1.Play();

        }
        else if (punch == 2 )
        {
            punch_2.Play();
        }
    }
}

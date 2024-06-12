using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGrab : MonoBehaviour
{
    public bool pickable;
    public float chrono;
    // Start is called before the first frame update
    void Start()
    {
        pickable = false;
        chrono = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickable)
        {
            chrono += Time.deltaTime;
        }

        if (chrono > 0.2f) 
        {
            pickable = false ;
        }

        if(!pickable) 
        {
            chrono = 0f; 
            gameObject.SetActive(false);
        }
    }

    public void ResetGrabText()
    {
        pickable = true;
        chrono = 0f;
    }
}

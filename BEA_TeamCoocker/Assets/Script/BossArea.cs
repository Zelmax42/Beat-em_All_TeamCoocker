using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
    public BossV1 Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Boss.isInArena = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Boss.isInArena = true;
    }
}

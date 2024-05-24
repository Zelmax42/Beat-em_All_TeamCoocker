using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public GameObject mob;
    public bool _canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canSpawn)
        {
            Vector2 spawnPosition = (Vector2)transform.position;

            //on recupere le mob

            GameObject Mobs = MobObjectPool.get();

            if (Mobs == null)
            {
                return;
            }

            //on active le mob
            Mobs.SetActive(true);

            //on teleporte le mob
            Mobs.transform.position = spawnPosition;
        }
    }
}

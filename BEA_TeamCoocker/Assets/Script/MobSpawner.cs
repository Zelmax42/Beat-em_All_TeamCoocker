using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public GameObject mob;
    public bool _canSpawn;
    private int _nbMobMin = 3;
    public int _mobCounter = 0;

    public float _nbHP;
    public float _damage;
    public float _speed;

    public MobType _Type;

    public enum MobType
    {
        NORMAL, BIG, SPEED
    }

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
            _mobCounter++;
        }
    }

    public void SelectMob()
    {
        float RandomType = Mathf.Round(Random.Range(0, 2));
        switch (RandomType)
        {
            case 0:
                _Type = MobType.BIG;
                break;
            case 1:
                _Type = MobType.SPEED;
                break;
        }

        if (_mobCounter > _nbMobMin)
        {

        }
    }
    public void MobInit(MobType Type)
    {
        EnnemyMovement mobSC = mob.GetComponent<EnnemyMovement>();

        switch (Type)
        {
            case MobType.NORMAL:
                mobSC._nbPV = 3f;
                mobSC._damage = 1f;
                mobSC._speed = 1f;
                break;
            case MobType.BIG:
                mobSC._nbPV = 5f;
                mobSC._damage = 3f;
                mobSC._speed = 0.5f;
                break;
            case MobType.SPEED:
                mobSC._nbPV = 2f;
                mobSC._damage = 1f;
                mobSC._speed = 3f;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobObjectPool : MonoBehaviour
{

    public int qtyToCreate = 10;
    public GameObject Mob;
    private static GameObject[] pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new GameObject[qtyToCreate];

        for (int i = 0; i < qtyToCreate; i++)
        {
            pool[i] = Instantiate(Mob, transform);
            pool[i].SetActive(false);
        }
    }
    public static GameObject get()
    {
        foreach (GameObject item in pool)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ennemiPool;
    public GameObject boss;
    public Boss bossSO;

    public int _count;

    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemiPool.activeSelf)
        {
            _count = 0;

            foreach (Transform ennemi in ennemiPool.GetComponentsInChildren<Transform>(true))
            {
                if (ennemi.CompareTag("Ennemi"))
                {
                    if (!ennemi.gameObject.activeSelf)
                    {
                        _count++;
                    }
                }
                
            }
            if(_count == 8)
            {
                ennemiPool.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ennemiPool.activeSelf)
        {
            boss.SetActive(true);
            bossSO.isActive = true;
            Camera.main.GetComponent<Clamping>().isTracking = false;
        }
    }
}

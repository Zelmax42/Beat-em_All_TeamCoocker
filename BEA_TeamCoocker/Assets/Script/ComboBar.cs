using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class ComboBar : MonoBehaviour
{
    //variable comoboPlayer
    public GameManagerSO gM;
    public int combo;
    public Image[] allStars;
    public Sprite fullStars;
    public Sprite emptyStars;
    public int numOfStars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        combo = gM.stateStars;

        if (combo > numOfStars)
        {
            combo = numOfStars;
        }

        for (int i = 0; i < allStars.Length; i++)
        {
            if (i < combo)
            {
                allStars[i].sprite = fullStars;
            }
            else
            {
                allStars[i].sprite = emptyStars;
            }
        }
    }
}

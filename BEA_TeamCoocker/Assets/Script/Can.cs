using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CanData;
using static UnityEngine.EventSystems.EventTrigger;

public class Can : MonoBehaviour
{
    public CanData canData;

    
 
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = GetComponent<Player>();
        if (player != null)
        {
            switch (canData.can)
            {
                case CanType.Life:
                //player.life += canData.value;
                    break;
                case CanType.Energy:
                //player.energy += canData.value;
                    break;
            }

            Destroy(gameObject);
        }

    }
}

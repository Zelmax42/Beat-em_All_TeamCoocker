using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static CanData;
using static UnityEngine.EventSystems.EventTrigger;

public class Can : MonoBehaviour
{
    public CanData canData;
    public UnityEvent OnPickUp;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.GetComponent<PlayerMovement>());

        PlayerMovement player = collider.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            switch (canData.can)
            {
                case CanType.Life:
                    player.GetLife(canData.value);
                    break;
                case CanType.Energy:
                    //player.energy += canData.value;
                    break;
            }

            OnPickUp.Invoke();
            Destroy(gameObject);
        }
       
           
        
    }

}

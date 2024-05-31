using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Punch : MonoBehaviour
{
        public Player playerData;
        public AudioSource audioSource; 

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                collision.GetComponent<Item>().Damaged();

                
                PlayPunchSound();
            }

            if (collision.gameObject.layer == 7)
            {
                collision.GetComponent<EnnemyMovement>().GotDamaged(playerData.dmgPlayer);

               
                PlayPunchSound();
            }
        }

        private void PlayPunchSound()
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }

    void Update()
    {

    }

}

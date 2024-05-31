using System;
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

          
           
            try
            {
               collision.GetComponent<EnnemyMovement>().GotDamaged(playerData.dmgPlayer);
            }
            catch(SystemException) { }
            try
            {
                collision.GetComponent<BossV1>().GotDamaged(playerData.dmgPlayer);
            }
            catch (SystemException) { }


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

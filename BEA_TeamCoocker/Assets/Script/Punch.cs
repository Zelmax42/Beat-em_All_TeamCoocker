using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Punch : MonoBehaviour
{
<<<<<<< HEAD
        public Player playerData;
        public AudioSource audioSource; 

        private void Start()
=======
    public Player playerData;
    public UnityEvent comboScore = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 )
>>>>>>> 4de39ad4a1b4d630251778e250bbed301c7811c0
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
<<<<<<< HEAD
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
=======
            comboScore.Invoke();
           
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

>>>>>>> 4de39ad4a1b4d630251778e250bbed301c7811c0
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //variable pvPlayer
    public Player _player;
    public Boss boss;
    public Image _PlayerPVimage;
    public Animator playerImage;
    private float _maxPV=50;
    private float _maxBossHP = 30;



    public Image bossJaugeImage;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Gestion de la barre de vie
        _PlayerPVimage.fillAmount = _player.pvPlayer / _maxPV;

        if ( _player.pvPlayer > 25f)
        {
            _PlayerPVimage.color = Color.green;
        }
        else if (_player.pvPlayer > 10f && _player.pvPlayer < 25f)
        {
            _PlayerPVimage.color = Color.yellow;
        }
        else if (_player.pvPlayer < 10f)
        {
            _PlayerPVimage.color = Color.red;
        }

        if(boss.isActive)
        {
            bossJaugeImage.transform.parent.gameObject.SetActive(true);
            bossJaugeImage.fillAmount = boss.bossHP / _maxBossHP;           
        }
        else
        {
            bossJaugeImage.transform.parent.gameObject.SetActive(false);
        }

        if (_player.currentStates == Player.States.HURT)
        {
            playerImage.SetTrigger("Hurted");
        }
    }

    public void CheckGameOver()
    {

    }
}

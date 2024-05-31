using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player _player;
    public Boss boss;
    public Image _PlayerPVimage;
    private float _maxPV=50;
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
            bossJaugeImage.gameObject.SetActive(true);
            bossJaugeImage.fillAmount = boss.bossHP / _maxPV;           
        }
        else
        {
            bossJaugeImage.gameObject.SetActive(false);
        }

    }

    public void CheckGameOver()
    {

    }
}

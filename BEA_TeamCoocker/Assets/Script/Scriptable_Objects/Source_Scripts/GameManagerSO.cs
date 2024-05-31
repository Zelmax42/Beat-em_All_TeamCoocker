using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "GM", menuName = "SO/GameManager", order = 0)]

public class GameManagerSO : ScriptableObject
{
    public int score = 0;
    public int hitEnnemy = 0;
    public int stateStars = 0;
    
    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
   
    public void CheckGameOver()
    {
        //levelChanger.FadeToNextLevel();
        SceneManager.LoadScene("UI_GameOver");
    }

    public void CheckWin()
    {
        SceneManager.LoadScene("UI_Win");
    }
    public void HitEnnemy(int value)
    {
        hitEnnemy += value;
        //1er étoiles
        if (hitEnnemy == 5)
        {
            stateStars += value;
        }
        //2eme étoiles
        if (hitEnnemy == 10)
        {
            stateStars += value;
        }
        //3eme étoiles
        if (hitEnnemy == 20)
        {
            stateStars += value;
        }
        //4eme étoiles
        if (hitEnnemy == 35)
        {
            stateStars += value;
        }
        //5eme étoiles
        if (hitEnnemy == 55)
        {
            stateStars += value;
        }
    }

    public void ComboBreaker()
    {
        hitEnnemy = 0;
        stateStars = 0;
    }
}

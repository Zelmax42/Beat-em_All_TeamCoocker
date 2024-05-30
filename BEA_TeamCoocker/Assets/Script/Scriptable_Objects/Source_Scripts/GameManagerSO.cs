using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "GM", menuName = "SO/GameManager", order = 0)]

public class GameManagerSO : ScriptableObject
{
    public LevelChanger levelChanger;
    public int score = 0;
    public int ennemyKills = 0;
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
    public void EnnemyKilled(int value)
    {
        ennemyKills += value;
        //1er étoiles
        if (ennemyKills == 5)
        {
            stateStars += value;
        }
        //2eme étoiles
        if (ennemyKills == 10)
        {
            stateStars += value;
        }
        //3eme étoiles
        if (ennemyKills == 15)
        {
            stateStars += value;
        }
        //4eme étoiles
        if (ennemyKills == 20)
        {
            stateStars += value;
        }
        //5eme étoiles
        if (ennemyKills == 25)
        {
            stateStars += value;
        }
    }

    public void AddScore(int value)
    {
        
        score += value;
       
        if (ennemyKills > 5) 
        {
            score += value * 2;
        }
       
        if (ennemyKills > 10)
        {
            score += value * 3;
        }
        
        if (ennemyKills > 15)
        {
            score += value * 4;
        }
        
        if (ennemyKills > 20)
        {
            score += value * 5;
        }
       
    }
}

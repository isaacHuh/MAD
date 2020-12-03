using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public TimerSO timer;

    // Update is called once per frame
    void Update()
    {
        if(timer.value <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //Scene change on death (timer <= 0)
        UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScreen");
        Debug.Log("GAME OVER");
    }
}

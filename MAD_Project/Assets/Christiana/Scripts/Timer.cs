using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Reference: https://stackoverflow.com/questions/36963125/level-timer-how-to-create-time-limit-in-unity
    // Start is called before the first frame update
    void Start()
    {
        //Time in seconds
        //I want to make it start at 120
        //Using 15 as the tester
        StartCoroutine(reloadTimer(15));
    }

    //Attach text to timerText
    public Text timerText;

    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = 0;

        while (counter < reloadTimeInSeconds)
        {
            counter += Time.deltaTime;
            timerText.text = counter.ToString();
            yield return null;
        }

        //Load new Scene
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
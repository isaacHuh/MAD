using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TimerSO timerData;

    public float timeToRemove;

    public float timeCounter;

    //Attach text to timerInfo
    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {

        timerData.resetTimer();

        timerText = this.GetComponent<TextMeshProUGUI>();

        updateDisplay();

        StartCoroutine(countdown(1));
        
    }

    void Update()
    {
        
    }

    public void updateDisplay()
    {
        int newTime = (int)timerData.value;
        timerText.text = newTime.ToString();
    }
    IEnumerator countdown(float reloadTimeInSeconds)
    {

        while (timerData.value > 0)
        {
            timerData.value -= Time.deltaTime;
            updateDisplay();
            yield return null;
        }

        //Need to set it up so if time >=, load DeathScene
        //but if they finish in the time limit, reload
        //Load new Scene
        //SceneManager.LoadScene(0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScreen");
    }
}

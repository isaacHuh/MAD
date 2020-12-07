using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Timer", menuName = "Assets/Timer")]
public class TimerSO : ScriptableObject
{
    public float value;

    public bool reset;

    public float resetValue;

    public void resetTimer()
    {
        //if (reset)
        //{
            value = resetValue;
            reset = false;
        //}
    }

    public void updateTimer(float timeToRemove)
    {

        value -= timeToRemove;
    }

    public void setReset()
    {
        reset = true;
    }
}

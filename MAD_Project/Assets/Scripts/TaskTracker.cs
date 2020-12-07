﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTracker : MonoBehaviour
{
    public List<GameObject> tasks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool complete = true;
        foreach(GameObject task in tasks){
            if(!task.GetComponent<TaskObject>().finished){
                complete = false;
            }
        }
        if(complete){
            Debug.Log("completed all tasks");
        }
    }
}

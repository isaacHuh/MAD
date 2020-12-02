using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject TaskManager;
    private bool startTask = false;

    
    public void InvokeTask(string TaskName){
        if(TaskName == "Trash")
            startTask = true;
        Debug.Log("Trash now has a task to watch out for");
    }

    public void InvokeTaskAtBeginning(){ //Testing purposes
        startTask = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (startTask == true){
            if (other.name == "TrashItem"){
                Debug.Log("Task Completed");
                startTask = false;
                TaskManager.SendMessage("FinishedTask", "Trash");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(startTask == true){
            if(other.name == "TrashItem"){
                Debug.Log("Task Completed");
                startTask = false;
                TaskManager.SendMessage("FinishedTask", "Trash");
            }
        }
    }

}

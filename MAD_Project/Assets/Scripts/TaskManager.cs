using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<GameObject> AllObjectsWithTasks = new List<GameObject>();//All objects that are associated with tasks
    private List<string> AllTasks = new List<string>();//All tasks that are currently possible
    private List<string> CurrentTasks = new List<string>();//All tasks that is currently assigned to the player
    private int assigned_tasks = 0;

    private void Start(){
        AllTasks.Add("Trash");
        assigned_tasks = 1;
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.KeypadEnter)){//Checks to see if the player is ready
            if (CurrentTasks.Count == 0){//Checks to see if the player has tasks to do
                AssignTasks(); //Assigns a task to the player
                Debug.Log("Task has been assigned");
            }
        }
    }

    private void AssignTasks(){
        int rngTask;

        for (int i = 0; i < assigned_tasks; i++){
            rngTask = (int)(Random.Range(0.0f, (AllTasks.Count - 1)));
            CurrentTasks.Add(AllTasks[rngTask]);
        }

        for (int i = 0; i < CurrentTasks.Count; i++){
            for (int j = 0; j < AllObjectsWithTasks.Count; j++){
                AllObjectsWithTasks[j].SendMessage("InvokeTask", CurrentTasks[i]);
            }
        }
    }

    public void FinishedTask(string TaskName){
        CurrentTasks.Remove(TaskName);
        if(CurrentTasks.Count == 0){
            assigned_tasks++;
        }
    }
}
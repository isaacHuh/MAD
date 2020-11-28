using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private List<string> AllTasks = new List<string>();//All tasks that are currently possible
    private List<string> CurrentTasks = new List<string>();//All tasks that is currently assigned to the player
    private int assigned_tasks = 1;

    private void Update(){
        if (Input.GetKeyDown(KeyCode.KeypadEnter)){//Checks to see if the player is ready
            if (CurrentTasks.Count == 0){//Checks to see if the player has tasks to do
                AssignTasks(); //Assigns a task to the player
            }
        }
    }

    private void AssignTasks(){
        int rng;
        List<int> exclude = new List<int>();

        for(int i = 0; i < assigned_tasks; i++){
            rng = (int)(Random.Range(1.0f, 3.0f));
            if (!(exclude.Contains(rng))){
                CurrentTasks.Add(AllTasks[rng]);
                //GameObject.Find(CurrentTasks[AllTasks[rng]]).GetComponent<Name of Component>().ActivateTask();  
                exclude.Add(rng);
            }
            else
                assigned_tasks--;
        }
    }

    public void FinishedTask(string TaskName){
        CurrentTasks.Remove(TaskName);
        if(CurrentTasks.Count == 0){
            assigned_tasks++;
        }
    }
}

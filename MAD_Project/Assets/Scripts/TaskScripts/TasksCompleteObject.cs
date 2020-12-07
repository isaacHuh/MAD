using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksCompleteObject : MonoBehaviour
{
    public GameObject taskObj;
    public Material highlightMat;

    public bool finished = false;
    bool hightlighted = false;
    public TimerSO timerData;
    // Update is called once per frame
    void Update()
    {
        if(finished && !hightlighted){
            Material[] mat = new Material[2];
            mat[0] = taskObj.transform.GetComponent<MeshRenderer>().material;
            mat[1] = highlightMat;
            taskObj.transform.GetComponent<MeshRenderer>().materials = mat;
            hightlighted = true;
        }   
    }

    void OnMouseDown() {
        Debug.Log("pressing button");
        if(finished){
            LevelManager.level++;
            UnityEngine.SceneManagement.SceneManager.LoadScene("IsaacScene");

            Debug.Log("button complete press");
        }
    }
}

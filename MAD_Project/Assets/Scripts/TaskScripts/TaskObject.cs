using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{
    public GameObject taskObj;
    public Material highlightMat;

    public bool finished = false;
    bool hightlighted = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TaskTracker").GetComponent<TaskTracker>().tasks.Add(gameObject);
        Material[] mat = new Material[2];
        mat[0] = taskObj.transform.GetComponent<MeshRenderer>().material;
        mat[1] = highlightMat;
        taskObj.transform.GetComponent<MeshRenderer>().materials = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished && hightlighted){
            Material[] mat = new Material[1];
            mat[0] = taskObj.transform.GetComponent<MeshRenderer>().material;
            taskObj.transform.GetComponent<MeshRenderer>().materials = mat;
            hightlighted = false;
        }   
    }
}

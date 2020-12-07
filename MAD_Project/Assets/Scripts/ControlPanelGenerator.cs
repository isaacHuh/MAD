using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelGenerator : MonoBehaviour
{
    public List<GameObject> tasks;
    // Start is called before the first frame update
    void Start()
    {
        int taskInt = Random.Range(0,tasks.Count);
        for(int i = 0; i < Mathf.Clamp(LevelManager.level,1,4); i++){
            int newTaskInt = Random.Range(0,tasks.Count);
            if(newTaskInt == taskInt){
                i--;
                continue;
            }else{
                taskInt = newTaskInt;
            }
            Instantiate(tasks[taskInt],transform.position + new Vector3(0,0.25f*i,0),transform.rotation,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

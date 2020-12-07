using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerTask : MonoBehaviour
{
    public GameObject bottle;
    public Material empty;
    void OnMouseDown() {
        if(bottle.GetComponent<MeshRenderer>().material != empty){
            bottle.GetComponent<MeshRenderer>().material = empty;
            //GameObject.Find("Main Camera").GetComponent<MouseLook>().angMult += 7.5f;
        }

        GetComponent<TaskObject>().finished = true;
    }
}

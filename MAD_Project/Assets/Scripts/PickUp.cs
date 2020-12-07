using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    // Start is called before the first frame update
    void Start()
    {
        theDest = GameObject.Find("Dest").transform;
    }


    void OnMouseDown() {
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.position = theDest.position;
        transform.parent = theDest.transform;
    }

    void OnMouseUp() {
        transform.parent = null;
        transform.GetComponent<Rigidbody>().useGravity = true;
    }

}

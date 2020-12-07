using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTask : MonoBehaviour
{
    void OnMouseDown() {
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().AddForce(-transform.forward*500);
    }

    IEnumerator Shoot(){
        yield return new WaitForSeconds(0.1f);
        Debug.Log("shoot");
        GetComponent<Rigidbody>().AddForce(-transform.forward*500);
    }
}

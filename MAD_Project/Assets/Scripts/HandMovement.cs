using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public Transform handTarget;
    public List<Transform> fingerIndex;
    List<Quaternion> startXRot = new List<Quaternion>();

    float targetFingerRot = -90f;
    float moveSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform index in fingerIndex) {
            Quaternion rot = index.localRotation;
            startXRot.Add(rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetMouseButton(0)) {
            float mouseX = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;

            Vector3 newPos = handTarget.localPosition + new Vector3(mouseX, 0, mouseY);

            newPos.x = Mathf.Clamp(newPos.x, -1.86f, -1f);

            newPos.z = Mathf.Clamp(newPos.z, 0.5f, 1.5f);

            handTarget.localPosition = newPos;
            
        }

        if (Input.GetKey(KeyCode.LeftControl) && !Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;

            Vector3 newPos = handTarget.localPosition + new Vector3(mouseX, mouseY, 0);

            newPos.x = Mathf.Clamp(newPos.x, -1.86f, -1f);

            newPos.y = Mathf.Clamp(newPos.y, 1.25f, 1.9f);

            handTarget.localPosition = newPos;

        }
        //finger 1
        for (int i = 0; i < fingerIndex.Count; i++)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 rot = fingerIndex[i].localRotation.eulerAngles;
                rot.x = targetFingerRot;
                fingerIndex[i].localRotation = Quaternion.Lerp(fingerIndex[i].localRotation, Quaternion.Euler(rot), 0.1f);
            }
            else if (fingerIndex[i].localRotation != startXRot[i])
            {
                fingerIndex[i].localRotation = Quaternion.Lerp(fingerIndex[i].localRotation, startXRot[i], 0.1f);
            }
        }

        if (Input.GetMouseButton(0))
        {
            GetComponent<Animator>().enabled = false;
        }
        else {
            GetComponent<Animator>().enabled = true;
        }

        /*
        //finger 2
        if (Input.GetKey(KeyCode.X))
        {
            Vector3 rot = fingerIndex[1].localRotation.eulerAngles;
            rot.x = targetFingerRot;
            fingerIndex[1].localRotation = Quaternion.Lerp(fingerIndex[1].localRotation, Quaternion.Euler(rot), 0.1f);
        }
        else if (fingerIndex[1].localRotation != startXRot[1])
        {
            fingerIndex[1].localRotation = Quaternion.Lerp(fingerIndex[1].localRotation, startXRot[1], 0.1f);
        }

        //finger 3
        if (Input.GetKey(KeyCode.C))
        {
            Vector3 rot = fingerIndex[2].localRotation.eulerAngles;
            rot.x = targetFingerRot;
            fingerIndex[2].localRotation = Quaternion.Lerp(fingerIndex[2].localRotation, Quaternion.Euler(rot), 0.1f);
        }
        else if (fingerIndex[2].localRotation != startXRot[2])
        {
            fingerIndex[2].localRotation = Quaternion.Lerp(fingerIndex[2].localRotation, startXRot[2], 0.1f);
        }

        //finger 4
        if (Input.GetKey(KeyCode.V))
        {
            Vector3 rot = fingerIndex[3].localRotation.eulerAngles;
            rot.x = targetFingerRot;
            fingerIndex[3].localRotation = Quaternion.Lerp(fingerIndex[3].localRotation, Quaternion.Euler(rot), 0.1f);
        }
        else if (fingerIndex[3].localRotation != startXRot[3])
        {
            fingerIndex[3].localRotation = Quaternion.Lerp(fingerIndex[3].localRotation, startXRot[3], 0.1f);
        }
        */
    }
}

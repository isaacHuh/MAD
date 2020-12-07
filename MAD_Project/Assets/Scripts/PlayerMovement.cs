using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            if(Input.GetMouseButtonDown(0)){
                if(hit.transform.tag == "Radial"){
                    hit.transform.GetComponent<TPC_RadialBC>().turning = true;
                    hit.transform.GetComponent<TaskObject>().finished = true;
                }
                if(hit.transform.tag == "Switch"){
                    hit.transform.GetComponent<TPC_SwitchBton>().turning = true;
                    hit.transform.GetComponent<TaskObject>().finished = true;
                }
                if(hit.transform.tag == "Slider"){
                    hit.transform.GetComponent<TPC_SliderC>().turning = true;
                    hit.transform.GetComponent<TaskObject>().finished = true;
                }
            }
        
            //print("I'm looking at " + hit.transform.name);
        }else{
            //print("I'm looking at nothing!");
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    float pushPower = 2.0f;
    float weight = 6.0f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        Vector3 force;

        // no rigidbody
        if (body == null || body.isKinematic) { return; }

        // We use gravity and weight to push things down, we use
        // our velocity and push power to push things other directions
        if (hit.moveDirection.y < -0.3)
        {
            force = new Vector3(0, -0.5f, 0) * gravity * weight;
        }
        else
        {
            force = hit.controller.velocity * pushPower;
        }

        // Apply the push
        body.AddForceAtPosition(force, hit.point);
    }
}

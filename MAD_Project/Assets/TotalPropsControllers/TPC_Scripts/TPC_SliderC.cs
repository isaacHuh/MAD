//TPC_SliderC demoScript version 1.0, this script is only for demo purposes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPC_SliderC : MonoBehaviour
{

    public enum SliderC_Mode { off = 0, manual = 1, automatic = 2, pingpong = 3 };
    public SliderC_Mode SliderM = SliderC_Mode.automatic;
    public float dispD;                                                      //distance from the center to the limit.

    private Vector3 InitialPos;

    public GameObject SliderControl;
    public float MovSpeed = 1.0f;
    private bool IsMoving = true;
    public bool MDirection = false;
    public float Movingtime=2;
    private float CurrenTime=0;
    public float Offtime = 4;
    private float CurrenOfftime = 0;

    // Use this for initialization
    void Start()
    {
        InitialPos = SliderControl.transform.localPosition; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (SliderM)
        {
            case SliderC_Mode.manual:
                Debug.Log("doingManual");
                break;
            case SliderC_Mode.automatic:
                DoAutomaticMode();
                break;
            case SliderC_Mode.pingpong:
                DoPingPongMode();
                break;

            default:
                //DoNothing
                break;
        }
    }

    void DoAutomaticMode()
    {
        // 0.040f
        CurrenTime += Time.deltaTime;

        if (IsMoving && CurrenTime < Movingtime)
        {
            if (MDirection)
            {               
                    SliderControl.transform.Translate(0, Time.deltaTime * -MovSpeed, 0);

                    if (SliderControl.transform.localPosition.z >= InitialPos.z + dispD)
                    {
                        MDirection = GenRandDirection();
                        //IsMoving = false;
                    }                                   
            }
            else
            {
                SliderControl.transform.Translate(0, Time.deltaTime * +MovSpeed, 0);

                if (SliderControl.transform.localPosition.z <= InitialPos.z - dispD)
                {
                    MDirection = GenRandDirection();
                    //IsMoving = false;
                }
            }
        }
        else
        {
            CurrenOfftime += Time.deltaTime;

            if(CurrenOfftime >= Offtime)
            {
                CurrenTime = 0;
                CurrenOfftime = 0;
                MDirection = GenRandDirection();
                Movingtime = Random.Range(0.5f, Movingtime);
            }
            
        }


    }

    void DoPingPongMode()
    {
       
        if (IsMoving && CurrenTime < Movingtime)
        {
            if (MDirection)
            {
                SliderControl.transform.Translate(0, Time.deltaTime * -MovSpeed, 0);

                if (SliderControl.transform.localPosition.z >= InitialPos.z + dispD)
                {
                    MDirection = GenRandDirection();                   
                }
            }
            else
            {
                SliderControl.transform.Translate(0, Time.deltaTime * +MovSpeed, 0);

                if (SliderControl.transform.localPosition.z <= InitialPos.z - dispD)
                {
                    MDirection = GenRandDirection();                  
                }
            }
        }


    }

    bool GenRandDirection()
    {
        int randomD = Random.Range(-1, 2);

        if (randomD >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

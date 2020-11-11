// TPC_GaugeInd demoScript version 1.0, this script is only for demo purposes.

using UnityEngine;
using System.Collections;

public class TPC_GaugeInd : MonoBehaviour
{

    public enum SliderC_Mode { off = 0, manual = 1, automatic = 2};
    public SliderC_Mode SliderM= SliderC_Mode.automatic; 
           
    public enum SliderC_Direction {Dstop=0 ,Dright = 1, Dleft = 2};
    public SliderC_Direction SliderDirect = SliderC_Direction.Dright;

    public GameObject IndObj;

    public float RotSpeed=20;           //Speed for the indicator needle.
    public float CurrentAngleY = 0;     //Current Euler"Y" Angle.
    public float TargetAngle = 0;       //Target angle.

    public float OffTime=1;              //Time off after reach the target angle.
    public float CurrentTime = 0;
    public bool CanMove = true;
    public bool EmmisiveOn = false;

    public Renderer rend;
    public Color colorStart;
    public Color colorEnd;



    // Use this for initialization
    void Start()
    {
       
        GenerateRandomAngle();
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

            default:
                EmmisiveOn = false;
                //DoNothing
                break;
        }

        if(EmmisiveOn)
        {
            DoEmmissiveTextOn();
        }

    }


    void DoAutomaticMode()
    {

        if(CanMove)
            {
            if (SliderDirect == SliderC_Direction.Dright)
                {
                      //Direction toRight 0-45 angle.  
                      if (IndObj.transform.localEulerAngles.y >=0 &&  IndObj.transform.localEulerAngles.y < 50)
                        {
                          IndObj.transform.Rotate(Vector3.forward, Time.deltaTime * RotSpeed);
                         
                           if(IndObj.transform.localEulerAngles.y >=TargetAngle)
                            {
                                CanMove = false;
                            }        
                        }
                     
                     if(IndObj.transform.localEulerAngles.y >=305 && IndObj.transform.localEulerAngles.y <=360)
                    {
                        IndObj.transform.Rotate(Vector3.forward, Time.deltaTime * RotSpeed);
                     }                    
                  }
                else
                {
                    //Direction toRight 315-360 angle.  
                    if ((IndObj.transform.localEulerAngles.y >=305 && IndObj.transform.localEulerAngles.y <360) )
                        {                      
                                IndObj.transform.Rotate(Vector3.forward, Time.deltaTime * -RotSpeed);

                            if (IndObj.transform.localEulerAngles.y <= TargetAngle)
                            {
                                CanMove = false;
                            }
                    }
                   if(IndObj.transform.localEulerAngles.y >= 0 && IndObj.transform.localEulerAngles.y <=50 )
                    {
                        IndObj.transform.Rotate(Vector3.forward, Time.deltaTime * -RotSpeed);
                      }
                }
        }
        else
        {
            //Check Off time and restart the movement.
            CurrentTime += Time.deltaTime;           

            if (CurrentTime>= OffTime)
            {
                GenerateRandomAngle();
                CanMove = true;
                CurrentTime = 0;               
            }
        }

        CurrentAngleY = IndObj.transform.localEulerAngles.y;
    }

    //Generate a random angle and set move direction.
    public void GenerateRandomAngle()
    {
        float temP= Random.Range(0,4);

        if(temP<2)
        {
            TargetAngle = Random.Range(0, 40);
            SliderDirect = SliderC_Direction.Dright;
        }
        else
        {
            TargetAngle = Random.Range(310, 358);
            SliderDirect = SliderC_Direction.Dleft;
        }
    }

    public void DoEmmissiveTextOn()
    {
        float lerp = Mathf.PingPong(Time.time, 3.0f) / 1.0f;
        Color c = (Color.Lerp(colorStart, colorEnd, lerp));
        rend.material.SetColor("_EmissionColor", c);

    }

}

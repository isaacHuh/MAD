//TPC_SwitchBton demoScript version 1.0, this script is only for demo purposes.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPC_SwitchBton : MonoBehaviour {

    public enum Switch_Mode { off = 0, manual = 1, automatic = 2 }
    public enum Switch_Pos { Up = 0, Down = 1 }
    public Switch_Mode SwitchM= Switch_Mode.automatic;
    public GameObject SwitchInterct;   
    public Switch_Pos ClickPosition;
    public bool turning = false;
    public float OffTime=4;
    private float CurrenTime;

    // Use this for initialization
    void Start () {
      
       //Start trigger with a ramdon initial postition.
       //doRandomInitPos();

        //Start trigger facing down
        SwitchInterct.transform.Rotate(SwitchInterct.transform.rotation.x - 45, 0, 0);
        ClickPosition = Switch_Pos.Down;
    }
	
	// Update is called once per frame
	void Update () {

        switch (SwitchM)
        {
            case Switch_Mode.manual:
                //Debug.Log("Switch-doingManual");//TODO
                if(turning){
                    DoManualMode();
                }
                break;
            case Switch_Mode.automatic:
                DoAutomaticMode();
                break;
            default:
                //DoNothing
                break;
        }
    }

    void DoAutomaticMode()
    {
        CurrenTime += Time.deltaTime;

        if (CurrenTime > OffTime)
        {
            doAutomaticSwitch();
            CurrenTime = 0;
           //OffTime = Random.Range(1, OffTime + 2);            //Uncoment this line if you whant to randomize the offtime.
        }
    }

    void DoManualMode()
    {

        doAutomaticSwitch();
        CurrenTime = 0;
        turning = false;
        //OffTime = Random.Range(1, OffTime + 2);            //Uncoment this line if you whant to randomize the offtime.

    }

    void doRandomInitPos()
    {
        int randomD = Random.Range(-1, 2);

        if (randomD >= 1)
        {
            SwitchInterct.transform.Rotate(SwitchInterct.transform.rotation.x + 45, 0, 0);
            ClickPosition = Switch_Pos.Up;
        }
        else
        {
            SwitchInterct.transform.Rotate(SwitchInterct.transform.rotation.x - 45, 0, 0);
            ClickPosition = Switch_Pos.Down;
        }
    }

    void doAutomaticSwitch()
    {

        if (ClickPosition == Switch_Pos.Up)
        {
            SwitchInterct.transform.Rotate(SwitchInterct.transform.rotation.y - 90, 0, 0);
            ClickPosition = Switch_Pos.Down;
        }
        else
        {
            SwitchInterct.transform.Rotate(SwitchInterct.transform.rotation.y + 90, 0, 0);
            ClickPosition = Switch_Pos.Up;
        }
    }


}

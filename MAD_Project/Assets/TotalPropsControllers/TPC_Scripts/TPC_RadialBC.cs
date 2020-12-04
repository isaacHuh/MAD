// TPC_RadialBC demoScript version 1.0, this script is only for demo purposes.

using UnityEngine;
using System.Collections;

public class TPC_RadialBC : MonoBehaviour {

    public enum RadialBC_Mode { off = 0, manual = 1, automatic = 2 }
    public enum RadialBC_Direction { Left = 0, Right = 1 }
    public RadialBC_Mode RadialBCMod= RadialBC_Mode.automatic;
    public RadialBC_Direction RadialBCDirection= RadialBC_Direction.Left;

    public GameObject RadialBCObject;
    public float MovSpeed=50;
    public float OffTime=1;
    public float MovingTime=3;
    private float CurrenTime;
    private float CurrenOffTime;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        switch (RadialBCMod)
        {
            case RadialBC_Mode.manual:
                Debug.Log("Switch-doingManual");//TODO
                break;

            case RadialBC_Mode.automatic:
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

        if (CurrenTime < MovingTime)
        {
            if (RadialBCDirection == RadialBC_Direction.Right)
            {
                RadialBCObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * MovSpeed));
            }

            if (RadialBCDirection == RadialBC_Direction.Left)
            {
                RadialBCObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -MovSpeed));
            }
        }

        if (CurrenTime > MovingTime)
        {
            CurrenOffTime += Time.deltaTime;

            if (CurrenOffTime > OffTime)
            {
                doOpositeDirection();
                CurrenTime = 0;
                CurrenOffTime = 0;
                OffTime = Random.Range(1, OffTime + 2);
            }
        }

    }


    void doOpositeDirection()
    {
        if (RadialBCDirection == RadialBC_Direction.Right)
        {
            RadialBCDirection = RadialBC_Direction.Left;
        }
        else
        {
            RadialBCDirection = RadialBC_Direction.Right;
        }

    }

}

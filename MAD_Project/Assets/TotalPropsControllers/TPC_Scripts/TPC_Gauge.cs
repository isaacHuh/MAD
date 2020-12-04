using UnityEngine;
using System.Collections;

public class TPC_Gauge : MonoBehaviour {

    public enum GaugeInd_Mode { off = 0, manual = 1, automatic = 2 }
    public enum GaugeInd_Direction { Left = 0, Right = 1 }
    public GaugeInd_Mode GaugeIndCMod;
    public GaugeInd_Direction GaugeIndDirection;

    public GameObject GaugeIndObject;

    public float OffSetPos;
    public float MovSpeed;
    public float OffTime;
    public float MovingTime;
    private float CurrenTime;
    private float CurrenOffTime;
    private float initRotPos;



    // Use this for initialization
    void Start()
    {

        initRotPos = GaugeIndObject.transform.rotation.y;

    }

    // Update is called once per frame
    void Update()
    {

        switch (GaugeIndCMod)
        {
            case GaugeInd_Mode.manual:
                Debug.Log("Switch-doingManual");
                break;

            case GaugeInd_Mode.automatic:
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
            if (GaugeIndDirection == GaugeInd_Direction.Right)
            {
                if (GaugeIndObject.transform.rotation.y < initRotPos + OffSetPos)
                {
                    GaugeIndObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * MovSpeed));
                    //GaugeIndObject.transform.Rotate(new Vector3(0, Time.deltaTime * MovSpeed, 0));

                }
                else if (GaugeIndObject.transform.rotation.y > initRotPos + OffSetPos)
                {
                    //stoptRotPos = GaugeIndObject.transform.rotation.y;
                }

            }

            if (GaugeIndDirection == GaugeInd_Direction.Left)
            {
                if (GaugeIndObject.transform.rotation.y > initRotPos - OffSetPos)
                {
                    GaugeIndObject.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -MovSpeed));

                }
                else if (GaugeIndObject.transform.rotation.y < initRotPos - OffSetPos)
                {
                    //stoptRotPos = GaugeIndObject.transform.rotation.y;
                }

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
                OffTime = Random.Range(0.5f, OffTime + 0.5f);
                MovingTime = Random.Range(1, MovingTime + 0.5f);
            }

        }

    }

    void doOpositeDirection()
    {
        if (GaugeIndDirection == GaugeInd_Direction.Right)
        {
            GaugeIndDirection = GaugeInd_Direction.Left;
        }
        else
        {
            GaugeIndDirection = GaugeInd_Direction.Right;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllers : MonoBehaviour
{

    public float counter = 0;
    public float counter1 = 0;
    public float counter2 = 0;


    public float speed;

    public PositionTracker positionTracker;
    public doorController doorcontrol;

    public Transform player;
    public Vector3 teleportPoint1;


    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    public bool moveKitchenDoor;
    public bool moveBarLongDoor;
    public bool moveBarShortDoor;



    // Use this for initialization
    void Start()
    {

        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    // Update is called once per frame
    void Update()
    {

        device = SteamVR_Controller.Input((int)trackedObj.index);


        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            device.TriggerHapticPulse(3000);
            Debug.Log("clicked trigger");
        }

        if (moveKitchenDoor == true)
        {
            if (counter == 0)
            {
                StartCoroutine(kitchenDoor(1));
                if (doorcontrol.KitchenDoor.transform.position.x >= 4)
                {
                    counter = 1;
                    moveKitchenDoor = false;
                }
            }
            else
            {
                StartCoroutine(kitchenDoor(-1));
                if (doorcontrol.KitchenDoor.transform.position.x <= 1.38f)
                {
                    counter = 0;
                    moveKitchenDoor = false;
                }
            }
        }

        if (moveBarLongDoor == true)
        {
            if (counter1 == 0)
            {
                StartCoroutine(barLongDoor(1));
                if (doorcontrol.BarDoorLong.transform.position.z <= 5.5f)
                {
                    counter1 = 1;
                    moveBarLongDoor = false;
                }
            }
            else
            {
                StartCoroutine(barLongDoor(-1));
                if (doorcontrol.BarDoorLong.transform.position.z >= 7.701897f)
                {
                    counter1 = 0;
                    moveBarLongDoor = false;
                }
            }
        }

        if (moveBarShortDoor == true)
        {
            if (counter2 == 0)
            {
                StartCoroutine(barShortDoor(1));
                if (doorcontrol.BarDoorShort.transform.position.x <= -4)
                {
                    counter2 = 1;
                    moveBarShortDoor = false;
                }
            }
            else
            {
                StartCoroutine(barShortDoor(-1));
                if (doorcontrol.BarDoorShort.transform.position.x >= -3.375608f)
                {
                    counter2 = 0;
                    moveBarShortDoor = false;
                }
            }
        }


        // if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        // {
        //     device.TriggerHapticPulse(3000);
        // }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("DOOR-KITCHEN"))
        {

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                moveKitchenDoor = true;
            }
        }

        if (col.gameObject.CompareTag("DOOR-BAR_LONG"))
        {

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                moveBarLongDoor = true;
            }
        }

        if (col.gameObject.CompareTag("DOOR-BAR_SHORT"))
        {

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                moveBarShortDoor = true;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DOOR-KITCHEN"))
        {
            device.TriggerHapticPulse(3000);
        }
        if (col.gameObject.CompareTag("DOOR-BAR_SHORT"))
        {
            device.TriggerHapticPulse(3000);
        }
        if (col.gameObject.CompareTag("DOOR-BAR_LONG"))
        {
            device.TriggerHapticPulse(3000);
        }
    }

    IEnumerator kitchenDoor(int dir)
    {
        Rigidbody rb = doorcontrol.KitchenDoor.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        doorcontrol.KitchenDoor.transform.Translate((dir * Vector3.right) * (Time.deltaTime));
        rb.isKinematic = true;
        yield return null;
    }

    IEnumerator barShortDoor(int dir)
    {
        Rigidbody rb = doorcontrol.KitchenDoor.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        doorcontrol.BarDoorShort.transform.Translate((dir * Vector3.right) * (Time.deltaTime));
        rb.isKinematic = true;
        yield return null;
    }
    IEnumerator barLongDoor(int dir)
    {
        Rigidbody rb = doorcontrol.KitchenDoor.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        doorcontrol.BarDoorLong.transform.Translate((dir * Vector3.left) * (Time.deltaTime));
        rb.isKinematic = true;
        yield return null;
    }
}

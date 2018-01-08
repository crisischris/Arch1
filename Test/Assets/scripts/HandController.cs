using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{


    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;


    //public doorController DoorController;



    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();


        // Update is called once per frame



    }

    void update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            device.TriggerHapticPulse(3000);
        }



        }


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Model"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                device.TriggerHapticPulse(3000);
                Debug.Log("CLicked");
            }


            //public void OnTriggerEnter(Collider col)
            //{
            //    if (col.gameObject.CompareTag("DOOR-KITCHEN"))
            //    {
            //        device.TriggerHapticPulse(3000);
            //
            //    }
            //}


            // void OnTriggerStay(Collider col)
            // {
            //     if (col.gameObject.CompareTag("DOOR-KITCHEN"))
            //     {
            //         if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            //         {
            //             DoorController.OpenKitchen();
            //         }
            //     }
            // }
        }
    }
}

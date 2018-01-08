using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {

    public GameObject KitchenDoor;
    public GameObject BarDoorLong;
    public GameObject BarDoorShort;

    public Vector3 startPosKitchen;
    public Vector3 startPosBarLong;
    public Vector3 startPosBarShort;

    public Vector3 endPosKitchen;
    public Vector3 endPosBarLong ;
    public Vector3 endPosBarShort;

    // Use this for initialization
    void Start () {

       startPosKitchen = KitchenDoor.transform.position;
       startPosBarLong = BarDoorLong.transform.position;
       startPosBarShort = BarDoorShort.transform.position;

         endPosKitchen = new Vector3(4f,KitchenDoor.transform.position.y, KitchenDoor.transform.position.z);
         endPosBarLong = new Vector3(BarDoorLong.transform.position.x, BarDoorLong.transform.position.y,5.51f);
         endPosBarShort = new Vector3(4.1f, BarDoorShort.transform.position.y, BarDoorShort.transform.position.z);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OpenKitchen()
    {
        KitchenDoor.transform.position = Vector3.Lerp(startPosKitchen, endPosKitchen, 3);
    }
}

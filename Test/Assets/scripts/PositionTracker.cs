using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracker : MonoBehaviour {

    public Vector3 currentPos;

	
	// Update is called once per frame
	void Update () {

          currentPos = gameObject.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMovement : MonoBehaviour {
    private GameObject mCam;
	// Use this for initialization
	void Start () {
        mCam = GameObject.Find("Player/Main Camera");	
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = mCam.transform.position;
        float angle_x = mCam.transform.localEulerAngles.x;
        float angle_y = mCam.transform.localEulerAngles.y;
        float angle_z = this.transform.eulerAngles.z;
        this.transform.eulerAngles = new Vector3(angle_x, angle_y, angle_z);
	}
}

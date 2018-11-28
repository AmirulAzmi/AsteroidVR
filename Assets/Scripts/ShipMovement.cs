using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    private GameObject mCam;
    public float speed = 2.0f;
	// Use this for initialization
	void Start () {
        mCam = GameObject.Find("Player/Main Camera");	
	}
	
	// Update is called once per frame
	void Update () {
        float interpolation = speed * Time.deltaTime;
        //this.transform.position = mCam.transform.position;
        float angle_x = Mathf.LerpAngle(this.transform.eulerAngles.x, mCam.transform.localEulerAngles.x, interpolation);
        float angle_y = Mathf.LerpAngle(this.transform.eulerAngles.y, mCam.transform.localEulerAngles.y, interpolation);
        float angle_z = this.transform.eulerAngles.z;
        this.transform.eulerAngles = new Vector3(angle_x, angle_y, angle_z);
	}
}

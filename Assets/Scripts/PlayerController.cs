using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public float RatePerSecond = 10.0f;

    private AudioSource aud;
    private GameController gm;
    private GameObject newShot;
    private float fireRate;
    private float nextShot = 0.5f;
    private float myTime = 0.0f;
	// Use this for initialization
	void Start () {
        fireRate = 1 / RatePerSecond;
        aud = GetComponent<AudioSource>();
        gm = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        myTime = myTime + Time.deltaTime;
        //Input.GetButton("Fire1")
        if ((Input.touchCount > 0 || Input.GetMouseButton(0) || gm.autoFire) && (myTime > nextShot)) {
            nextShot = myTime + fireRate;
            newShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            nextShot = nextShot - myTime;
            myTime = 0.0f;
            aud.Play();
        }
	}
}

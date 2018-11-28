using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;
    private AudioSource aud;
    public int strength = 1;
    private int point;
    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        aud = GetComponent<AudioSource>();
        point = strength;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Boundary")
        {
            if (other.tag == "Laser")
            {
                aud.Play();
                strength--;
                if (strength <= 0)
                {
                    aud.Play();
                    Instantiate(explosion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    gameController.AddScore(point);
                }
            }
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                Instantiate(explosion, transform.position, transform.rotation);
                gameController.GameOver();
            }
            Destroy(other.gameObject);
        }
        else return;
    }
}

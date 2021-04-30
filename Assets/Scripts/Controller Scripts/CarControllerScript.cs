using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    public float speed = 2000;
    public float rotationSpeed = 500f;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    public Rigidbody2D rb;

    private float movement = 0f;
    private float tiltrotation = 0f;

    public AudioSource carAudioSource;
    public AudioClip driveClip, hitBoxClip, collectCoinClip;

    public GameObject continuePanel;

    void Update(){
        Movement();
    }

    void Movement(){
        movement = -Input.GetAxisRaw("Vertical") * speed;
        tiltrotation = Input.GetAxisRaw("Horizontal");
        //carAudioSource.PlayOneShot(driveClip);
    }
    void FixedUpdate() {
        if(movement == 0f){
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else{
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rb.AddTorque(-tiltrotation * rotationSpeed * Time.fixedDeltaTime);
        
    }
    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Box"){
            carAudioSource.PlayOneShot(hitBoxClip);
            Debug.Log("You hit a box.");
            Destroy(target.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Finish Line"){
            Debug.Log("You have reached the finish line.");
            continuePanel.SetActive(true);
        }
        else if(target.tag == "Coin"){
            carAudioSource.PlayOneShot(collectCoinClip);
            GameObject.Find("Gameplay Controller").GetComponent<GameplayControllerScript>().coins += 1;
            Debug.Log("You earned a coin.");
            Destroy(target.gameObject);
        }
    }
}

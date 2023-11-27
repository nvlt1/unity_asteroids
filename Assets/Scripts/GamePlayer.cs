using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    public float speed_of_thrust = 1.0f;
    public float turningSpeed = 1.0f;

    private bool isThrusting;

    private float turningDirection;
    private Rigidbody2D myRigidBody;

    private void Awake(){
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        isThrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turningDirection = 1.0f;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            turningDirection = -1.0f;
        } else {
            turningDirection = 0.0f;
        }

        
        
    }

    private void FixedUpdate() {
        if (isThrusting){
            myRigidBody.AddForce(this.transform.up * this.speed_of_thrust);
        }

        if (turningDirection != 0.0f){
            myRigidBody.AddTorque(turningDirection * this.turningSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    //instantiate bullet
    public Bullet bulletPrefab;
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

        // shoots everytime you press it, to shoot must press again for GetKeyDown
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootBullets();
        }
        
        
    }

    private void FixedUpdate() {
        if (isThrusting){
            //transform.up ensures we thrust in one direction only
            myRigidBody.AddForce(this.transform.up * this.speed_of_thrust);
        }

        if (turningDirection != 0.0f){
            myRigidBody.AddTorque(turningDirection * this.turningSpeed);
        }
    }

    private void ShootBullets(){
        //position and rotation to spawn bullets at players position
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Projectile(this.transform.up);
    }



    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Asteroid"){

            myRigidBody.velocity = Vector3.zero;
            myRigidBody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDeath();

        }
    }

    // player daeth
    // private void OnCollisionEnter2D(Collision2D collision) {

    //     if (collision.gameObject.tag == "Asteroid"){
    //         // player death, stop all movement
    //         myRigidBody.velocity = Vector3.zero;
    //         myRigidBody.angularVelocity = 0.0f;

    //         this.gameObject.SetActive(false); 

    //         //
    //         FindObjectOfType<GameManager>().PlayerDeath();

    //     }
    // }

}



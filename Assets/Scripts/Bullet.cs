using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    // bullet life time so it doesn't exist forever.
    public float maxLifeTime = 10.0f;

    private Rigidbody2D myRigidBody;

    private void Awake(){
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Projectile(Vector2 direction){

        // once bullet is fired, adds force to the bullet
        myRigidBody.AddForce(direction * this.speed);

        // destorys bullet eventually
        Destroy(this.gameObject, this.maxLifeTime);
    }

    // called when bullet collides with an object
    public void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);
    }


    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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

    public void Project(Vector2 direction){
        myRigidBody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
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

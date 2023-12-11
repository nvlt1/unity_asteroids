using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    // array of sprites to pick a random asteroid in Start()
    public Sprite[] sprites;

    // this gets randomized when we spawn asteroids, 1.0 just a set value
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;

    // references sprite renderer to change which sprite is rendered
    private SpriteRenderer mySpriteRenderer;
    //reference to rigid body
    private Rigidbody2D myRigidBody;
    
    private void Awake(){
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        //randomizing size and rotation + sprite
        // eularAngles represent 3 dimensional rotation by doing 3 separate rotations around individual axes
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f); // x, y, z values, z * 360 degrees
        //add uniqueness to asteroids, changes mass of each object
        this.transform.localScale = Vector3.one * this.size; // vector3.one is just x, y, z values all = 1 

        myRigidBody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction){
        myRigidBody.AddForce(direction * this.speed);
        
        Destroy(this.gameObject, this.maxLifeTime);
    }

    // Asteroid splitter
    private void OnCollisionEnter2D(Collision2D collision){

        // splits only on bullet hits
        if (collision.gameObject.tag == "Bullet"){
            // if current size of asteroid can be divided by 2, and is bigger than minsize of 0.5, split asteroid
            if ((this.size * 0.5f) >= this.minSize){
                
                // Split asteroid twice
                AsteroidSplit();
                AsteroidSplit();
            }

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject); // destroying current asteroid
        }
    }

    private void AsteroidSplit(){

        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f; // new asteroids after split don't spawn on same point

        Asteroids splitHalf = Instantiate(this, position, this.transform.rotation);
        splitHalf.size = this.size * 0.5f;
        splitHalf.SetTrajectory(Random.insideUnitCircle.normalized * this.speed); //randomized split direction
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// awake is called when the script obj (asteroid here) is initialized whether or not script is enabled
// awake is used to set up references between scripts and START is used to pass any information back and forth

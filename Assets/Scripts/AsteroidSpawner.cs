using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // reference to asteroid prefab to instantiate it
    public Asteroids asteroidPrefab;

    // variance for asteroids so they don't just attack the center but curve around it
    public float trajectoryVar = 15.0f;
    public float spawnDist = 14.0f; // scene at roughly x:11, spawn outside the scene 
    public float spawnRate = 2.0f; // every 2 second
    public int spawnAmt = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    //spawn new asteroids at a regular rate
    // invokes a method every x amount of seconds over and over for asteroid spawns
    InvokeRepeating(nameof(Spawn),this.spawnRate, this.spawnRate); // y, z = intial time to call this, and how often to repeat
        
    }

    private void Spawn(){

        
        
        for (int i = 0; i < this.spawnAmt; i++) {

            // RANDOM spawn point
            // generates random point inside the cirlce or on the circle
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDist; // normalized sets magnitude to 1 so asteroids spawn on edge of circle
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            // RANDOM direction
            float variance = Random.Range(-this.trajectoryVar, this.trajectoryVar);
            //rotation represented with quaternions
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); // AngleAxis(angle, axis - z axis), .forward is (0, 0, 1)

            // object instantiation
            Asteroids asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation); // rotation gives it's trajectory as well 

            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

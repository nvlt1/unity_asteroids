using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // reference to the player
    public GamePlayer gamePlayer;
    public ParticleSystem explosion;
    public int lives = 3;
    public int score = 0;
    public float respawnTimer = 3.0f;

    

    public void PlayerDeath(){

        this.explosion.transform.position = this.gamePlayer.transform.position;
        this.explosion.Play();
        this.lives--;

        if (this.lives <= 0) {
            GameOver();
        } else {
            //player invoke respawn
            Invoke(nameof(Respawn), this.respawnTimer); 
        }
    }

    private void Respawn(){
        // reset player position
        this.gamePlayer.transform.position = Vector3.zero;
        this.gamePlayer.gameObject.SetActive(true);
    }

    private void GameOver(){
        //TODO
    }

    public void AsteroidDestroyed(Asteroids asteroid){
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.75f){
            this.score += 60;
        } else if (asteroid.size < 1.0f) {
            this.score += 40;
        } else {
            this.score += 20;
        }
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

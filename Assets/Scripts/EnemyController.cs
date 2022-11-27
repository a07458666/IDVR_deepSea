using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // movement range
    public float rangeH = 5;
    public float rangeV = 1;
   
    // speed
    public float speed = 2;

    // enemy hp
    public int hp = 3;

    // isSplit
    public bool isSplit = false;

    // direction
    int direction = 1;

    // accumulated movement
    float accMovement = 0;

    // hit move
    float hitMoveRate = 18;

     // available states
    enum State { MovingHorizontally, MovingVertically, Dead};
    
    // keep track of the current state
    State currState;

    // Game Manager
    GameManager gm;

    // Enemy Manager
    EnemyManager em;


    // Start is called before the first frame update
    void Start()
    {
        // initial state
        currState = State.MovingHorizontally;

        // game manager
        gm = GameObject.FindObjectOfType<GameManager>();

        // log error if it wasn't found
        if (gm == null)
        {
            Debug.LogError("there needs to be an GameManager in the scene");
        }

        // enemy manager
        em = GameObject.FindObjectOfType<EnemyManager>();

        // log error if it wasn't found
        if (em == null)
        {
            Debug.LogError("there needs to be an EnemyManager in the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // nothing happens if the enemy is dead
        if (currState == State.Dead) return;

        // calculate movement  v = d / t --> d = v * t
        float movement = speed * Time.deltaTime;

        // update accumulate movement
        accMovement += movement;

        // are we moving horizontally?
        if (currState == State.MovingHorizontally)
        {
            // if yes, then transition to moving vertically
            if(accMovement >= rangeH)
            {
                // transition to moving vertically
                currState = State.MovingVertically;

                // reverse direction (for horizontal movement)
                direction *= -1;

                // reset acc movement
                accMovement = 0;
            }
            // if not, move the invader horizontally
            else
            {
                transform.position += transform.forward * movement * direction;
            }
        }
        // this is, if we are moving vertically
        else
        {
            // if yes, then transition to moving horizontally
            if (accMovement >= rangeV)
            {
                // transition to moving horiz
                currState = State.MovingHorizontally;

                // reset acc movement
                accMovement = 0;
            }
            // if not, move the invader vertically
            else
            {
                transform.position += Vector3.down * movement;
            }
        }
    }

    public void SplitEnemy(Vector3 startPos, Vector3 scale)
    {
        em.numEnemies+=3;
        for (int i = 0; i < 3; i++)
        {
            // spawn enemy
            GameObject newEnemy = Instantiate(em.enemyPrefab);

            newEnemy.GetComponent<EnemyController>().hp = 1;
            newEnemy.GetComponent<EnemyController>().speed = 1;
            newEnemy.GetComponent<EnemyController>().isSplit = true;
            // set enemy position
            newEnemy.transform.position = new Vector3(startPos.x + i - 1, startPos.y, startPos.z + i - 1);
            newEnemy.transform.localScale = scale / 3;
        }
    }

    public void KillEnemy()
    {
        // nothing will happen if already dead
        if (currState == State.Dead) return;

        if (hp > 0) 
        {
            hp-=1;
            
            if (gm.m_wave == 1)
            {
                setBOSSHP(gameObject.GetComponent<EnemyController>().hp);
            }
            else
            {
                transform.position += hitMoveRate * Vector3.up * Time.deltaTime;
            }
            return;
        }

        // set the state to dead
        currState = State.Dead;

        //[implement your own effect here]
        GameObject enemyDieParticle = Instantiate(em.enemyDieEffect, transform.position, transform.rotation);
        enemyDieParticle.GetComponent<AudioSource>().Play(0);
        
        // Split Enemy
        if (gameObject.GetComponent<EnemyController>().isSplit == false)
        {
            SplitEnemy(gameObject.transform.position, gameObject.transform.localScale);
        }

        //[Example]
        Destroy(gameObject);

        Destroy(enemyDieParticle, 5);
        //[End of Example]

        // decrease number of enemies
        em.numEnemies--;
        
        em.killEnemies++;
        setKillText();

        // check winning condition
        gm.HandleEnemyDead();
    }

    void setKillText()
    {
        gm.killText.text = "Kill : " + em.killEnemies.ToString();
    }

    void setBOSSHP(int hp)
    {
        gm.killText.text = "BOSS HP : " + hp.ToString() + "/ 1000";
    }

    void OnTriggerEnter(Collider other)
    {
        // nothing will happen if already dead
        if (currState == State.Dead) return;

        //check if the enemy hit the player
        if (other.CompareTag("Player Body"))
        {
            gm.GameOver();
        }

        //check if the enemy reached the floor
        else if (other.CompareTag("Ground"))
        {
            gm.GameOver();
        }
    }
}

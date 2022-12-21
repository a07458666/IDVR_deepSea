using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float maxDistance = 30;

    public GameManager gm;

    public GameObject coinSound;
    public GameObject gummySound;
    public GameObject biggummySound;
    public int shoot = 0;

    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // difference in all coordinate
        float diffX = Mathf.Abs(initPos.x - transform.position.x);
        float diffY = Mathf.Abs(initPos.y - transform.position.y);
        float diffZ = Mathf.Abs(initPos.z - transform.position.z);

        // destroy if it's too far away
        if(diffX >= maxDistance || diffY >= maxDistance || diffZ >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        shoot += 1;
        // check if we hit an enemy
        if(other.CompareTag("Enemy") )
        {
            other.gameObject.GetComponent<EnemyController>().KillEnemy();
            GameObject newgummySound = Instantiate(gummySound);
            Destroy(gameObject);

        }
        else if (other.CompareTag("coin"))
        {
            other.gameObject.GetComponent<EnemyController>().KillCoin();
            GameObject newcoinSound = Instantiate(coinSound);
            Destroy(gameObject);
        }
        else if (other.CompareTag("BigGummy"))
        {
            other.gameObject.GetComponent<BigGummyController>().KillBigGummy();
            GameObject bigGummySound = Instantiate(biggummySound);
            Destroy(gameObject);
        }
        // check if we hit the graffiti
        else if(other.CompareTag("Graffiti")) {
            Debug.Log("start game");
            gm.InitGame();
            Destroy(gameObject);
        }

        //if (shoot >=2)
            //Destroy(gameObject);
    }
}

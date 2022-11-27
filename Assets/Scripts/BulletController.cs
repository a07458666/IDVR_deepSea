﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float maxDistance = 30;

    public GameManager gm;

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
        // check if we hit an enemy
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().KillEnemy();
        }
        // check if we hit the graffiti
        else if(other.CompareTag("Graffiti")) {            
            gm.InitGame(0);
        }
        // check if we hit the graffiti
        else if(other.CompareTag("BOSS")) { 
            gm.InitGame(1);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    // Bullet velocity
    public float bulletSpeed = 10;
    public float Ai = 10;
    public float drift = 0.1f;
    // Hand
    public GameObject rightHand;
    public GameObject leftHand;

    // bullet prefab
    public GameObject bulletPrefab;

    [Range(0.01f, 1f)]
    public float speedH = 1.0f;
    [Range(0.01f, 1f)]
    public float speedV = 1.0f;

    // shotgun
    public float maxAngle = 60.0f;

    GameManager gm;
    float yaw = -90.0f;
    float pitch = 0.0f;

    Vector3 moveValue;

    


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        moveValue = new Vector3(0.0f, 0.0f, 0.0f);

    }

    void Update()
    {
        // transform.eulerAngles = new Vector3(pitch, yaw, 0f);

    }

    void FixedUpdate()
    {
        // transform.position += moveValue;
        // transform.Translate(moveValue);
    }

    public void OnFire()
    {
        Debug.Log("OnFire");
        AudioSource audioData = rightHand.GetComponent<AudioSource>();
        audioData.Play(0);

        // spawn a new bullet
        GameObject newBullet = Instantiate(bulletPrefab);

        // pass the game manager
        newBullet.GetComponent<BulletController>().gm = gm;

        // position will be that of the rightHand
        newBullet.transform.position = rightHand.transform.position;

        // get rigid body
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

        // give the bullet velocity
        bulletRb.velocity = rightHand.transform.forward * bulletSpeed;
    }

    Vector3 GetRandomDir()
    {
        Vector3 direction = rightHand.transform.forward; // your initial aim.
        Vector3 spread = Vector3.zero;
        spread+= rightHand.transform.up * Random.Range(-1f, 1f); // add random up or down (because random can get negative too)
        spread+= rightHand.transform.right * Random.Range(-1f, 1f); // add random left or right

        // Using random up and right values will lead to a square spray pattern. If we normalize this vector, we'll get the spread direction, but as a circle.
        // Since the radius is always 1 then (after normalization), we need another random call. 
        direction += Vector3.Normalize(spread) * Random.Range(0f, 0.6f);
        return direction;
    }

    public void OnStrongFire()
    {
        AudioSource audioData = rightHand.GetComponent<AudioSource>();
        audioData.Play(0);
        for (int i = 0; i < 9; i++)
        {   
            Vector3 rightHandDir = GetRandomDir();
            // spawn a new bullet
            GameObject newBullet = Instantiate(bulletPrefab);

            // pass the game manager
            newBullet.GetComponent<BulletController>().gm = gm;

            // position will be that of the rightHand
            newBullet.transform.position = rightHand.transform.position + new Vector3((i / 3) * drift, (i % 3) * drift, 0);
            // newBullet.transform.scale = new Vector3(0.01f, 0.01f, 0.01f);
            // get rigid body
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

            // give the bullet velocity
            bulletRb.velocity = GetRandomDir() * bulletSpeed;
        }
        
    }

    void OnLook(InputValue value)
    {
        var delta = value.Get<Vector2>();

        yaw += speedH * delta.x;
        pitch -= speedV * delta.y;

        pitch = Mathf.Clamp(pitch, -90f, 90f);
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Application is focussed");
        }
        else
        {
            Debug.Log("Application lost focus");
        }
    }

    void OnMove(InputValue value)
    {
        var move = value.Get<Vector2>();
        Debug.Log("OnMove" + move.x.ToString() + move.y.ToString());
        moveValue = new Vector3(move.x, 0.0f, move.y);
    }
}

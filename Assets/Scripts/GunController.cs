using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GunController : MonoBehaviour
{
    // Bullet velocity
    public float bulletSpeed = 10;
    public float drift = 0.1f;
    // bullet prefab
    public GameObject bulletPrefab;
    // shotgun
    public float maxAngle = 60.0f;
    // Start is called before the first frame update
    GameManager gm;

    [Range(0, 1)]
    public float intensity;
    public float duration;

    public XRBaseController controllerLeft;
    public XRBaseController controllerRight;
    public GameObject controllerHead;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        //XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // = GetComponent<XRBaseController>();
        // controllerHead.SendHapticImpulse(intensity, duration);

    }

    public void OnFire()
    {
        AudioSource audioData = this.GetComponent<AudioSource>();
        audioData.Play(0);

        // spawn a new bullet
        GameObject newBullet = Instantiate(bulletPrefab);

        // pass the game manager
        newBullet.GetComponent<BulletController>().gm = gm;

        // position will be that of the this
        newBullet.transform.position = this.transform.position + (this.transform.forward / 2);

        // get rigid body
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

        // give the bullet velocity
        bulletRb.velocity = this.transform.forward * bulletSpeed;
        controllerLeft.SendHapticImpulse(intensity, duration);
        controllerRight.SendHapticImpulse(intensity, duration);
    }

    Vector3 GetRandomDir()
    {
        Vector3 direction = this.transform.forward; // your initial aim.
        Vector3 spread = Vector3.zero;
        spread += this.transform.up * Random.Range(-1f, 1f); // add random up or down (because random can get negative too)
        spread += this.transform.right * Random.Range(-1f, 1f); // add random left or right

        // Using random up and right values will lead to a square spray pattern. If we normalize this vector, we'll get the spread direction, but as a circle.
        // Since the radius is always 1 then (after normalization), we need another random call. 
        direction += Vector3.Normalize(spread) * Random.Range(0f, 0.6f);
        return direction;
    }

    public void OnStrongFire()
    {
        AudioSource audioData = this.GetComponent<AudioSource>();
        audioData.Play(0);
        for (int i = 0; i < 9; i++)
        {
            Vector3 thisDir = GetRandomDir();
            // spawn a new bullet
            GameObject newBullet = Instantiate(bulletPrefab);

            // pass the game manager
            newBullet.GetComponent<BulletController>().gm = gm;

            // position will be that of the this
            newBullet.transform.position = this.transform.position + new Vector3((i / 3) * drift, (i % 3) * drift, 0) + this.transform.forward;
            // newBullet.transform.scale = new Vector3(0.01f, 0.01f, 0.01f);
            // get rigid body
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

            // give the bullet velocity
            bulletRb.velocity = GetRandomDir() * bulletSpeed;
        }
        controllerLeft.SendHapticImpulse(intensity, duration);
        controllerRight.SendHapticImpulse(intensity, duration);
    }
}

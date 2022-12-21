using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftprint_prefab;
    public GameObject rightrint_prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generate_left(){
        GameObject fingerprint1 = Instantiate(leftprint_prefab);
        fingerprint1.transform.position = new Vector3(transform.position.x +0.5f, transform.position.y, transform.position.z);
        Debug.Log("TEST LEFT !");
    }

    public void generate_right(){
        GameObject fingerprint2 = Instantiate(rightrint_prefab);
        fingerprint2.transform.position = new Vector3(transform.position.x -0.5f, transform.position.y, transform.position.z);
        Debug.Log("TEST RIGHT !");
    }
}

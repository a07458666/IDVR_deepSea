using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCheck_right : MonoBehaviour
{
    // Start is called before the first frame update
    public bool right_check = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rightprint")) 
        {
            right_check = true;
        }
    }
}

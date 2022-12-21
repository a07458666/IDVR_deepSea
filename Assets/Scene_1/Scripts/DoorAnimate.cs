using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    PrintCheck_left pl;
    PrintCheck_right pr;
    void Start()
    {
        pl = GameObject.FindObjectOfType<PrintCheck_left>();
        pr = GameObject.FindObjectOfType<PrintCheck_right>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pl.left_check && pr.right_check)
        {
            Debug.Log("open");
            if(transform.position.y <= 37.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y+0.007f, transform.position.z);
            }
        }
        
        
    }
}

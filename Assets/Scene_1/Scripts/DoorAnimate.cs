using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    PrintCheck_left pl;
    PrintCheck_right pr;
    public GameObject fade_scene_change;
    private bool isTrigger = false;
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
            change_sence();
        }
        
        
    }

    void change_sence()
    {
        if (isTrigger) return;
        isTrigger = true;
        //Get script attached to it
        fade_in_out _fade_in_out = fade_scene_change.GetComponent<fade_in_out>();

        //Call the function
        _fade_in_out.Scene_change_by_time();
    }

}

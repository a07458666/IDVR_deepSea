using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRecede : MonoBehaviour
{
    public bool animated_start = false;

    private float speed = 0.015f;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        animated_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(animated_start && this.transform.position.y > -1){
            timer += Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
        }
    }

    public void start_animation(){
        animated_start = true;
        timer = 0;
    }
}

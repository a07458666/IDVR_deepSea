using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.1f, this.transform.localScale.z);
    }

    public void UnPress()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.2f, this.transform.localScale.z);
    }

}

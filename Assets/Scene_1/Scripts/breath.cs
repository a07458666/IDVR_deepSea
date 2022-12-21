using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breath : MonoBehaviour
{
    // Start is called before the first frame update
    float count = 0.0f;
    public AudioSource hurtAudio;
    void Start()
    {
        //gameObject.SetActive(false);
        hurtAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 4){
            //gameObject.SetActive(true);
            hurtAudio.Play();
            count = 0.0f;
        }
        //gameObject.SetActive(false);
        
    }
}

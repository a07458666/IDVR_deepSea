using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class image_switch : MonoBehaviour
{
    public RawImage Img1;
    public RawImage Img2;
    public RawImage Img3;
    public RawImage Img4;  
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Img1.gameObject.SetActive(true);
        Img2.gameObject.SetActive(false);
        Img3.gameObject.SetActive(false);
        Img4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(){
        index++;
        index %= 4;
        switch (index)
        {
            case 0:
                Img1.gameObject.SetActive(true);
                Img2.gameObject.SetActive(false);
                Img4.gameObject.SetActive(false);
                break;
            case 1:
                Img2.gameObject.SetActive(true);
                Img1.gameObject.SetActive(false);
                Img3.gameObject.SetActive(false);
                break;
            case 2:
                Img3.gameObject.SetActive(true);
                Img2.gameObject.SetActive(false);
                Img4.gameObject.SetActive(false);
                break;
            case 3:
                Img4.gameObject.SetActive(true);
                Img3.gameObject.SetActive(false);
                Img1.gameObject.SetActive(false);
                break;
            break;
        }
    }

    public void Ruduce(){
        index += 3;
        index %= 4;
        switch (index)
        {
            case 0:
                Img1.gameObject.SetActive(true);
                Img2.gameObject.SetActive(false);
                Img4.gameObject.SetActive(false);
                break;
            case 1:
                Img2.gameObject.SetActive(true);
                Img1.gameObject.SetActive(false);
                Img3.gameObject.SetActive(false);
                break;
            case 2:
                Img3.gameObject.SetActive(true);
                Img2.gameObject.SetActive(false);
                Img4.gameObject.SetActive(false);
                break;
            case 3:
                Img4.gameObject.SetActive(true);
                Img3.gameObject.SetActive(false);
                Img1.gameObject.SetActive(false);
                break;
            break;
        }
    }
}

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
    public RawImage Img5;
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Img1.gameObject.SetActive(true);
        Img2.gameObject.SetActive(false);
        Img3.gameObject.SetActive(false);
        Img4.gameObject.SetActive(false);
        Img5.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(){
        index++;
        index %= 5;
        Img1.gameObject.SetActive(false);
        Img2.gameObject.SetActive(false);
        Img3.gameObject.SetActive(false);
        Img4.gameObject.SetActive(false);
        Img5.gameObject.SetActive(false);
        switch (index)
        {
            case 0:
                Img1.gameObject.SetActive(true);
                break;
            case 1:
                Img2.gameObject.SetActive(true);
                break;
            case 2:
                Img3.gameObject.SetActive(true);
                break;
            case 3:
                Img4.gameObject.SetActive(true);
                break;
            case 4:
                Img5.gameObject.SetActive(true);
                break;

        }
    }

    public void Ruduce(){
        index += 4;
        index %= 5;
        Img1.gameObject.SetActive(false);
        Img2.gameObject.SetActive(false);
        Img3.gameObject.SetActive(false);
        Img4.gameObject.SetActive(false);
        Img5.gameObject.SetActive(false);
        switch (index)
        {
            case 0:
                Img1.gameObject.SetActive(true);
                break;
            case 1:
                Img2.gameObject.SetActive(true);
                break;
            case 2:
                Img3.gameObject.SetActive(true);
                break;
            case 3:
                Img4.gameObject.SetActive(true);
                break;
            case 4:
                Img5.gameObject.SetActive(true);
                break;

        }
    }
}

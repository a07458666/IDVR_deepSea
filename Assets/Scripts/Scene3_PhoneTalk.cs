using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI objects
using UnityEngine.XR.Interaction.Toolkit;

public class Scene3_PhoneTalk : MonoBehaviour
{
    // define notification and phone screen
    public Button PhoneNotification;
    public Button ReplyBubbleLeft1, ReplyBubbleRight1, ReplyBubble_2, ReplyBubble_3;
    public GameObject talk1, talk2, talk3;

    public float intensity = 0.1f, duration = 1.0f;
    public bool firstClicked = false;

    private AudioSource beep; // add


    // Start is called before the first frame update
    void Start()
    {
        talk1.GetComponent<AudioSource>();
        talk2.GetComponent<AudioSource>();
        talk3.GetComponent<AudioSource>();
        beep = GetComponent<AudioSource>(); // add

        Button PhoneNotificationbtn = PhoneNotification.GetComponent<Button>();
        // PhoneNotificationbtn.onClick.AddListener(TaskOnClick);
        Button ReplyBubble1 = ReplyBubbleLeft1.GetComponent<Button>();
        ReplyBubble1.onClick.AddListener(Reply1OnClick);
        Button ReplyBubbler1 = ReplyBubbleRight1.GetComponent<Button>();
        ReplyBubbler1.onClick.AddListener(Reply1OnClick);
        Button ReplyBubble2 = ReplyBubble_2.GetComponent<Button>();
        ReplyBubble2.onClick.AddListener(Reply2OnClick);
        Button ReplyBubble3 = ReplyBubble_3.GetComponent<Button>();
        ReplyBubble3.onClick.AddListener(Reply3OnClick);

        /*XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerVibration);*/

        PhoneNotification.gameObject.SetActive(false);
        ReplyBubbleLeft1.gameObject.SetActive(false);
        ReplyBubbleRight1.gameObject.SetActive(false);
        //ReplyBubbleLeft1.animationTriggers.CrossFade("fadeIn", 3.0);
        ReplyBubble_2.gameObject.SetActive(false);
        ReplyBubble_3.gameObject.SetActive(false);

        Invoke("phoneRang", 40f);
    }

    void phoneRang()
    {
        PhoneNotification.gameObject.SetActive(true); 
        if (firstClicked == false) // talkie keep beeping 
        {
            Debug.Log("Talkie beeping.");
            beep.Play();
            beep.loop = true;
            firstClicked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstClicked == true && PhoneNotification.IsActive() == false)
            {
                Debug.Log("grab talkie and hide notification.");
                firstClicked = false; // then never enter this loop again
                PhoneNotification.gameObject.SetActive(false);

                // play audio 1
                beep.loop = false;
                beep.Stop();
                Instantiate(talk1);

                Invoke("popMsg1", 10f); // delay pop up msg after talking 
            }
    }


    void popMsg1()
    {
        ReplyBubbleLeft1.gameObject.SetActive(true);
        ReplyBubbleRight1.gameObject.SetActive(true);
    }
    void Reply1OnClick()
    {
        Debug.Log("Pressed reply1.");
        ReplyBubbleLeft1.gameObject.SetActive(false);
        ReplyBubbleRight1.gameObject.SetActive(false);

        // play audio 2
        Instantiate(talk2);
        Invoke("popMsg2", 6f); // delay 
    }

    void popMsg2()
    {
        ReplyBubble_2.gameObject.SetActive(true);
    }
    void Reply2OnClick()
    {
        Debug.Log("Pressed reply2.");
        ReplyBubble_2.gameObject.SetActive(false);

        // play audio 3
        Instantiate(talk3);
        Invoke("popMsg3", 6f); // delay 
    }
    void popMsg3()
    {
        ReplyBubble_3.gameObject.SetActive(true);
    }

    void Reply3OnClick()
    {
        Debug.Log("Pressed reply3.");
        ReplyBubble_3.gameObject.SetActive(false);
        // end the scene
    }
}

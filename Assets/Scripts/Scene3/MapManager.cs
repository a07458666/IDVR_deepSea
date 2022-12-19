using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class MapManager : MonoBehaviour
{
    public bool isTrigger_A = false;
    public bool isTrigger_B = false;
    public bool isTrigger_C = false;
    public object taget;
    public GameObject plesiosaurus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger_A && isTrigger_B && isTrigger_C)
        {
            Debug.Log("Unlock!!!");
            transform.DOShakePosition(5.0f, new Vector3(0.5f, 0.5f, 0));
            isTrigger_A = false;
            isTrigger_B = false;
            isTrigger_C = false;
            plesiosaurus.SetActive(true);
        }
    }

    public void CheckMap_A(HoverEnterEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab A: " + obj.name);
        if (obj.name == "Tarot_Card_A")
        {
            isTrigger_A = true;
        }
    }

    public void CheckMap_B(HoverEnterEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab B: " + obj.name);
        if (obj.name == "Tarot_Card_B")
        {
            isTrigger_B = true;
        }
    }

    public void CheckMap_C(HoverEnterEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab C: " + obj.name);
        if (obj.name == "Tarot_Card_C")
        {
            isTrigger_C = true;
        }
    }

    public void SelectMap_A(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab A: " + obj.name);
        if (obj.name == "Tarot_Card_A")
        {
            isTrigger_A = true;
        }
    }

    public void SelctMap_B(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab B: " + obj.name);
        if (obj.name == "Tarot_Card_B")
        {
            isTrigger_B = true;
        }
    }

    public void SelectMap_C(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab C: " + obj.name);
        if (obj.name == "Tarot_Card_C")
        {
            isTrigger_C = true;
        }
    }

    public void ExitMap_A(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab A: " + obj.name);
        if (obj.name == "Tarot_Card_A")
        {
            isTrigger_A = false;
        }
    }

    public void ExitMap_B(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab B: " + obj.name);
        if (obj.name == "Tarot_Card_B")
        {
            isTrigger_B = false;
        }
    }

    public void ExitMap_C(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab C: " + obj.name);
        if (obj.name == "Tarot_Card_C")
        {
            isTrigger_C = false;
        }
    }
}

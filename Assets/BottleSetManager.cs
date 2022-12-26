using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class BottleSetManager : MonoBehaviour
{
    public bool isTrigger_A = false;
    public bool isTrigger_B = false;
    public bool isTrigger_C = false;
    public bool isTrigger_D = false;
    public bool isTrigger_E = false;
    public object taget;
    public GameObject plesiosaurus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger_A && isTrigger_B && isTrigger_C && isTrigger_D && isTrigger_E)
        {
            Debug.Log("Unlock!!!");
            transform.DOShakePosition(5.0f, new Vector3(0.5f, 0.5f, 0));
            isTrigger_A = false;
            isTrigger_B = false;
            isTrigger_C = false;
            isTrigger_D = false;
            isTrigger_E = false;
            plesiosaurus.SetActive(true);
        }
    }

    public void CheckMap_A(HoverEnterEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab A: " + obj.name);
        if (obj.name == "Bottle1")
        {
            isTrigger_A = true;
        }
    }

    public void CheckMap_B(HoverEnterEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab B: " + obj.name);
        if (obj.name == "Bottle2")
        {
            isTrigger_B = true;
        }
    }

    public void CheckMap_C(HoverEnterEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab C: " + obj.name);
        if (obj.name == "Bottle3")
        {
            isTrigger_C = true;
        }
    }

    public void SelectBottle_A(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab A: " + obj.name);
        if (obj.name == "Bottle1")
        {
            isTrigger_A = true;
        }
    }

    public void SelectBottle_B(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab B: " + obj.name);
        if (obj.name == "Bottle2")
        {
            isTrigger_B = true;
        }
    }

    public void SelectBottle_C(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab C: " + obj.name);
        if (obj.name == "Bottle3")
        {
            isTrigger_C = true;
        }
    }
    public void SelectBottle_D(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab D: " + obj.name);
        if (obj.name == "Bottle4")
        {
            isTrigger_D = true;
        }
    }
    public void SelectBottle_E(SelectEnterEventArgs args)
    {
        IXRSelectInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab E: " + obj.name);
        if (obj.name == "Bottle5")
        {
            isTrigger_E = true;
        }
    }

    public void ExitBottle_A(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab A: " + obj.name);
        if (obj.name == "Bottle1")
        {
            isTrigger_A = false;
        }
    }

    public void ExitBottle_B(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab B: " + obj.name);
        if (obj.name == "Bottle2")
        {
            isTrigger_B = false;
        }
    }

    public void ExitBottle_C(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab C: " + obj.name);
        if (obj.name == "Bottle3")
        {
            isTrigger_C = false;
        }
    }
    public void ExitBottle_D(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab D: " + obj.name);
        if (obj.name == "Bottle4")
        {
            isTrigger_D = false;
        }
    }
    public void ExitBottle_E(HoverExitEventArgs args)
    {
        IXRHoverInteractable hoverComponent = args.interactableObject;
        GameObject obj = hoverComponent.transform.gameObject;
        Debug.Log("Grab E: " + obj.name);
        if (obj.name == "Bottle5")
        {
            isTrigger_E = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_controller_helper : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    private XROrigin xROrigin;
    private CharacterController characterController;
    private CharacterControllerDriver driver;*/
    void Start()
    {
        /*
        xROrigin = GetComponent<CharacterController>();
        characterController = GetComponent<CharacterControllerDriver>();
        */
    }

    // Update is called once per frame
    void Update()
    {/*
        UpdateCharacterController();*/
    }

    /*
    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (xROrigin == null || characterController == null)
            return;

        var height = Mathf.Clamp(xROrigin.CameraInOriginSpaceHeight, driver.minHeight, maxHeight);

        Vector3 center = xROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;
    }*/

}

using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraManager : MonoBehaviour {

    public Camera primaryCamera;
    public Camera secondaryCamera;
    public ThirdPersonSwimmerController playerController; //Optional to override controller input
    public CameraInputType currentCameraInput = CameraInputType.FirstPersonCamera;

    public enum CameraInputType
    {
        FirstPersonCamera,
        ThirdPersonCamera
    }

    internal Camera activeCamera;

    void Awake()
    {
        activeCamera = primaryCamera;
    }

    void Start()
    {
        primaryCamera.gameObject.SetActive(true);
        secondaryCamera.gameObject.SetActive(false);
    }

	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            if(activeCamera == primaryCamera)
            {
                primaryCamera.GetComponent<CameraUnderwater>().ResetCamera();
                primaryCamera.gameObject.SetActive(false);
                secondaryCamera.gameObject.SetActive(true);

                activeCamera = secondaryCamera;
            }
            else
            {
                secondaryCamera.GetComponent<CameraUnderwater>().ResetCamera();
                secondaryCamera.gameObject.SetActive(false);
                primaryCamera.gameObject.SetActive(true);

                activeCamera = primaryCamera;
            }

            if(currentCameraInput == CameraInputType.FirstPersonCamera)
            {
                currentCameraInput = CameraInputType.ThirdPersonCamera;
            }
            else
            {
                currentCameraInput = CameraInputType.FirstPersonCamera;
            }

        }
	
	}
}

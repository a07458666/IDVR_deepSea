using UnityEngine;
using System.Collections;
using UnityStandardAssets;
using UnityEngine.Rendering.PostProcessing; //uncomment me
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraUnderwater : MonoBehaviour {

    public GameObject causticLight;
    public Color underwaterFogColor = new Color(0, 0.619f, 0.780f);

    private float waterLevel = -999;
    private MeshRenderer aboveWaterMesh;
    private MeshRenderer belowWaterMesh;

    private bool cameraUnderwater = false;
    private CameraManager camManager;
    private PostProcessVolume _volume; //uncomment me
    private PostProcessProfile _profile;
    private DepthOfField _depthOfField;
    private Color startingFogColor;

    void Start()
    {
        camManager = FindObjectOfType<CameraManager>();
        _volume = GetComponent<PostProcessVolume>();
        _profile = _volume.profile;
        _profile.TryGetSettings<DepthOfField>(out _depthOfField);
        if (_depthOfField == null)
        {
            Debug.Assert(true, "Depth of filed post process effect not set on post process volume profile");
        }
        startingFogColor = RenderSettings.fogColor;
    }

    void Update()
    {
        if(transform.position.y < waterLevel)
        {
            if (cameraUnderwater == false)
            {
                ResetToBelowWater();
            }
        }
        else
        {
            if (cameraUnderwater == true)
            {
                ResetToAboveWater();
            }
        }
    }

    public void ResetCamera()
    {
        ResetToAboveWater();
        waterLevel = -999;
    }

    public void ResetToBelowWater()
    {
        if (aboveWaterMesh != null && belowWaterMesh != null)
        {
            cameraUnderwater = true;
            RenderSettings.fogStartDistance = 10;
            RenderSettings.fogEndDistance = 80;
            Camera.main.farClipPlane = 300;
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            RenderSettings.fogColor = underwaterFogColor;

            aboveWaterMesh.enabled = false;
            belowWaterMesh.enabled = true;


            //Uncomment this block
            if (camManager != null)
            {
                if (camManager.activeCamera.GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>() != null)
                {
                    camManager.activeCamera.GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>().active = true;
                }
            }
            else if (_volume != null)
            {
                _depthOfField.active = true;
            }

            if (causticLight != null)
            {
                causticLight.SetActive(true);
            }
        }
    }

    public void ResetToAboveWater()
    {
        if (aboveWaterMesh != null && belowWaterMesh != null)
        {
            cameraUnderwater = false;
            RenderSettings.fogStartDistance = 200;
            RenderSettings.fogEndDistance = 300;
            Camera.main.farClipPlane = 400;
            Camera.main.clearFlags = CameraClearFlags.Skybox;
            RenderSettings.fogColor = startingFogColor;

            aboveWaterMesh.enabled = true;
            belowWaterMesh.enabled = false;

            //Uncomment this block
            if (camManager != null)
            {
                if (camManager.activeCamera.GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>() != null)
                {
                    camManager.activeCamera.GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>().active = true;
                }
            }
            else if (_volume != null)
            {
                _depthOfField.active = false;
            }

            if (causticLight != null)
            {
                causticLight.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterLevel = other.transform.position.y;
            aboveWaterMesh = other.transform.GetComponent<MeshRenderer>();
            belowWaterMesh = other.transform.GetChild(0).GetComponent<MeshRenderer>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterLevel = -999;
        }
    }


}

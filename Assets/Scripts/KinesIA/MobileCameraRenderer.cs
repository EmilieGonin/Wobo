using UnityEngine;
using UnityEngine.UI;

public class MobileCameraRenderer : MonoBehaviour
{
    [SerializeField] private RawImage _cameraRenderer;
    private WebCamTexture webCam;

    void Start()
    {
        string cameraName = GetFrontFacingCameraName();
        webCam = new WebCamTexture(cameraName);

        _cameraRenderer.texture = webCam;
        webCam.Play();
    }

    private string GetFrontFacingCameraName()
    {
        foreach (var device in WebCamTexture.devices)
        {
            if (device.isFrontFacing)
            {
                return device.name;
            }
        }
        return null;
    }
}

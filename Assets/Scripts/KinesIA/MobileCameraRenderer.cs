using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileCameraRenderer : MonoBehaviour
{
    WebCamTexture webCam;
    [SerializeField] private RawImage _cameraRenderer;

    void Start()
    {
        // Rechercher les périphériques caméra disponibles
        WebCamDevice[] devices = WebCamTexture.devices;
        string frontCameraName = null;

        // Chercher la caméra frontale dans les périphériques
        foreach (var device in devices)
        {
            if (device.isFrontFacing)
            {
                frontCameraName = device.name;
                break;
            }
        }

        if (frontCameraName != null)
        {
            webCam = new WebCamTexture(frontCameraName);
        }
        else
        {
            webCam = new WebCamTexture();
        }

        _cameraRenderer.texture = webCam;
        webCam.Play();
    }
}

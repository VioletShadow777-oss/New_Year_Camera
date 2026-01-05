using UnityEngine;
using UnityEngine.UI;

public class SimpleCamera : MonoBehaviour
{
    public RawImage display;
    public AspectRatioFitter fitter;

    [HideInInspector] // Hide in inspector but keep public for the Shifter script
    public bool lookingForFront;

    private WebCamTexture camTexture;
    private bool isCameraRunning = false;

    void Start()
    {
        // Set initial preference based on platform
#if UNITY_WEBGL && !UNITY_EDITOR
            lookingForFront = !Application.isMobilePlatform; 
#elif UNITY_ANDROID && !UNITY_EDITOR
            lookingForFront = false; 
#else
        lookingForFront = true;
#endif

        InitializeCamera();
    }

    // Changed to PUBLIC so the Shifter can call it
    public void InitializeCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0) return;

        // CRITICAL: Stop the old camera stream before starting a new one
        if (camTexture != null)
        {
            camTexture.Stop();
            isCameraRunning = false;
        }

        WebCamDevice selectedDevice = devices[0];
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == lookingForFront)
            {
                selectedDevice = devices[i];
                break;
            }
        }

        camTexture = new WebCamTexture(selectedDevice.name, 1920, 1080);
        display.texture = camTexture;
        camTexture.Play();

        isCameraRunning = true; // Ensure Update() runs to fix rotation
    }

    void Update()
    {
        if (!isCameraRunning || camTexture == null || !camTexture.isPlaying) return;

        float videoRotationAngle = -camTexture.videoRotationAngle;


        // Rotates the Raw Image according the camera its facing 
        if(lookingForFront == false)
        {
            display.rectTransform.localEulerAngles = new Vector3(0, 0, videoRotationAngle);

        }
        else if(lookingForFront == true)
        {
            display.rectTransform.localEulerAngles = new Vector3(0, 180, videoRotationAngle);
             
        }

        if (fitter != null)
        {
            float aspectRatio = (float)camTexture.width / (float)camTexture.height;
            fitter.aspectRatio = aspectRatio;
        }
    }
}
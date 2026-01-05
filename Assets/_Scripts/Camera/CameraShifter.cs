using UnityEngine;

public class CameraShifter : MonoBehaviour
{
    // Drag your GameObject with the SimpleCamera script into this slot in the Inspector
    public SimpleCamera cameraController;

    public void ShiftCamera()
    {
        // Check if the device actually has more than one camera
        if (WebCamTexture.devices.Length <= 1)
        {
            Debug.Log("Only one camera detected. Cannot shift.");
            return;
        }

        if (cameraController != null)
        {
            // 1. Toggle the boolean inside the main script
            cameraController.lookingForFront = !cameraController.lookingForFront;

            // 2. Tell the main script to restart with the new setting
            cameraController.InitializeCamera();

            Debug.Log("Camera Shift Triggered. New target: " +
                      (cameraController.lookingForFront ? "Front" : "Back"));
        }

        //if (AudioManager.instance != null) AudioManager.instance.PlayClickSound();
    }


    
}
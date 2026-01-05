using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

public class WebGLCameraCapture : MonoBehaviour
{
    [Header("UI References")]
    public GameObject uiToHide;    // The panel containing your buttons
    public RawImage previewImage;  // (Optional) To show the photo in-app after taking it

    [DllImport("__Internal")]
    private static extern void DownloadFile(byte[] array, int byteLength, string fileName);

    private Texture2D lastCapturedTexture;

    // Call this from your UI Button
    public void CaptureAndSave()
    {
        StartCoroutine(CaptureRoutine());
    }

    private IEnumerator CaptureRoutine()
    {
        // 1. Hide UI so buttons aren't in the photo
        if (uiToHide != null) uiToHide.SetActive(false);

        // 2. Wait for the frame to render (Essential for a clean shot)
        yield return new WaitForEndOfFrame();

        // 3. Clean up previous texture to save RAM (Critical for WebGL!)
        if (lastCapturedTexture != null) Destroy(lastCapturedTexture);

        // 4. Capture the screen
        lastCapturedTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // 5. Update preview in UI (if assigned)
        if (previewImage != null)
        {
            previewImage.texture = lastCapturedTexture;
            previewImage.gameObject.SetActive(true);
        }

        // 6. Convert to PNG and Trigger Download
#if UNITY_WEBGL && !UNITY_EDITOR
            byte[] textureBytes = lastCapturedTexture.EncodeToPNG();
            string fileName = "Photo_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            DownloadFile(textureBytes, textureBytes.Length, fileName);
#else
        Debug.Log("Capture successful! Download only triggers in WebGL Build.");
#endif

        // 7. Bring the UI back
        if (uiToHide != null) uiToHide.SetActive(true);
    }
}
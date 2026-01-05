using UnityEngine;
using UnityEngine.UI;

public class FireWorkManager : MonoBehaviour
{
    public GameObject fireWork;

    private bool isActive;

    // Components
    public Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        fireWork.SetActive(false);
        isActive = false;

    }

    public void ManageFireWrok()
    {
        Color imageColor = buttonImage.color;
        // Enables Firework
        if(isActive == false)
        {
            fireWork.SetActive (true);
            isActive = true;

            // Changes the Opacity to 0.5f
            imageColor.a = 0.5f;
        }

        // Disables Firework
        else
        {
            fireWork.SetActive(false);
            isActive = false;

            // Changes the Opacity to 1f
            imageColor.a = 1f;
        }

        // Play Clik Sound
        AudioManager.instance.PlayClickSound();

        // Assiging the Changed Image color
        buttonImage.color = imageColor;
    }
}

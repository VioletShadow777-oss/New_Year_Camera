using JetBrains.Annotations;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject snapShotUI;
    [Space]
    public GameObject fireWorkUI;
    [Space]
    public GameObject infoPanel;
    [Space]
    public GameObject hadiBhaiBanner;

    private bool isInfoActive;

    private bool isHadiBhaiActive;


    private void Start()
    {
        snapShotUI.SetActive(true);
        
        hadiBhaiBanner.SetActive(true);

        infoPanel.SetActive(false);

        isHadiBhaiActive = true;
        isInfoActive = false;
    }

    // Enables the firework UI and disables the SnapshotUI
    // Goes with the Snapshot Button
    public void FireworkUIEnable()
    {
        fireWorkUI.SetActive(true);
        snapShotUI.SetActive(false);
    }

    // Enables the Snapshot and disables the Firework UI
    // Goes with the Resume camera button
    public void SnapshotUIEnable()
    {
        fireWorkUI.SetActive(false);
        snapShotUI.SetActive(true);


    }

    // Manages the Info Panel Activation and Disabling
    public void InfoPanelManager()
    {
        // Playes the Sound
        AudioManager.instance.PlayClickSound();
        if(isInfoActive == false)
        {
            infoPanel.SetActive (true);
            isInfoActive = true;
        }
        else
        {
            infoPanel.SetActive (false);
            isInfoActive = false;
        }
    }

    // Manages the Hadi bhai panel
    public void HadiBhaiBanner()
    {
        if(isHadiBhaiActive == true)
        {
            hadiBhaiBanner.SetActive(false);
            isHadiBhaiActive = false;
        }
        else
        {
            hadiBhaiBanner.SetActive(true);
            isHadiBhaiActive = true;
        }
    }
}

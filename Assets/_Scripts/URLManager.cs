using UnityEngine;

public class URLManager : MonoBehaviour
{
    private string growbrandlyURL = "https://www.facebook.com/growbrandly";
    private string gameRaftURL = "https://www.facebook.com/profile.php?id=61576875822850";

    
    public void OpenGrowbrandly()
    {
        Application.OpenURL(growbrandlyURL);
    }

    public void OpenGameRaft()
    {
        Application.OpenURL(gameRaftURL);
    }
}

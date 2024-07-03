using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundPanel;
    public Sprite[] backgroundImages;

    private int currentBackgroundIndex = 0;

    void Start()
    {
        if (backgroundImages.Length > 0)
        {
            backgroundPanel.sprite = backgroundImages[currentBackgroundIndex];
        }
    }

    public void ChangeBackground()
    {
        currentBackgroundIndex = (currentBackgroundIndex + 1) % backgroundImages.Length;
        backgroundPanel.sprite = backgroundImages[currentBackgroundIndex];
    }
}

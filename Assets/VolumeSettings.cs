using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;

    public void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        audioMixer.SetFloat("music", 10);
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        if (volume == 0)
        {
            audioMixer.SetFloat("music", -80f);
        }
        else
        {
            audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        }
    }
}
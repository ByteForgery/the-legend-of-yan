using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    [Header("Video Settings")] 
    [SerializeField] private TMP_Dropdown graphicsModeDropdown;
    
    private void Start()
    {
        if (SoundSystem != null)
        {
            masterSlider.value = SoundSystem.MasterVolume;
            sfxSlider.value = SoundSystem.SFXVolume;
            musicSlider.value = SoundSystem.MusicVolume;
        }

        // Audio
        masterSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        
        // Video
        graphicsModeDropdown.onValueChanged.AddListener(OnGraphicsModeChanged);
    }

    // Audio
    private void OnMasterVolumeChanged(float value)
    {
        if (SoundSystem != null)
            SoundSystem.MasterVolume = value;
    }
    
    private void OnSFXVolumeChanged(float value)
    {
        if (SoundSystem != null)
            SoundSystem.SFXVolume = value;
    }
    
    private void OnMusicVolumeChanged(float value)
    {
        if (SoundSystem != null)
            SoundSystem.MusicVolume = value;
    }

    // Video
    private void OnGraphicsModeChanged(int mode)
    {
        QualitySettings.SetQualityLevel(mode, true);
    }

    private SoundSystem SoundSystem => SoundSystem.Instance;
}
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    public class SettingsMenuBehaviour : MonoBehaviour
    {
        [Header("References")]
        public GameObject settingsPanel;
        public TMP_Dropdown resolutionDropdown;
        public AudioMixer musicAudioMixer;
        public AudioMixer soundEffectAudioMixer;
        public Slider musicSlider;
        public Slider soundEffectSlider;
        public Toggle fullscreenToggle;
        
        private Resolution[] _resolutions;
        private int _currentIndexOfResolution;

        private void Awake()
        {
            _resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
            resolutionDropdown.ClearOptions();

            InitializePlayerPrefs();

            List<string> resolutionOptions = new List<string>();

            for (int i = 0; i < _resolutions.Length; i++)
            {
                resolutionOptions.Add(_resolutions[i].width + "x" + _resolutions[i].height);
                if (PlayerPrefs.GetInt("resolutionWidth") == _resolutions[i].width &&
                    PlayerPrefs.GetInt("resolutionHeight") == _resolutions[i].height)
                {
                    _currentIndexOfResolution = i;
                }
            }
            
            resolutionDropdown.AddOptions(resolutionOptions);
            resolutionDropdown.value = _currentIndexOfResolution;
            
            float musicVolume = PlayerPrefs.GetFloat("musicVolume");
            float soundEffectVolume = PlayerPrefs.GetFloat("soundEffectVolume");
            bool isFullscreen = PlayerPrefs.GetInt("isFullscreen") == 1;
            
            musicSlider.value = musicVolume;
            soundEffectSlider.value = soundEffectVolume;
            fullscreenToggle.isOn = isFullscreen;
            
            SetFullscreen(isFullscreen);
            UpdateMusicAudioVolume(musicVolume);
            UpdateSoundEffectAudioVolume(soundEffectVolume);
            SetResolution(_currentIndexOfResolution);
        }

        public void UpdateSoundEffectAudioVolume(float soundEffectVolume)
        {
            
            soundEffectAudioMixer.SetFloat("volume", soundEffectVolume);
            
            // On sauvegarde le volume dans les PlayerPrefs
            PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);
        }

        private void InitializePlayerPrefs()
        {
            if (!PlayerPrefs.HasKey("resolutionWidth"))
            {
                PlayerPrefs.SetInt("resolutionWidth", Screen.currentResolution.width);
            }

            if (!PlayerPrefs.HasKey("resolutionHeight"))
            {
                PlayerPrefs.SetInt("resolutionHeight", Screen.currentResolution.height);
            }

            if (!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 0);
            }
            
            if (!PlayerPrefs.HasKey("soundEffectVolume"))
            {
                PlayerPrefs.SetFloat("soundEffectVolume", 0);
            }
            
            if (!PlayerPrefs.HasKey("isFullscreen"))
            {
                PlayerPrefs.SetInt("isFullscreen", 1);
            }
        }

        public void OpenSettings()
        {
            settingsPanel.SetActive(true);
        }
        
        public void CloseSettings()
        {
            settingsPanel.SetActive(false);
        }
        
        public void UpdateMusicAudioVolume(float volume)
        {
            musicAudioMixer.SetFloat("volume", volume);
            
            // On sauvegarde le volume dans les PlayerPrefs
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
        
        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            
            // On sauvegarde le mode plein écran dans les PlayerPrefs
            PlayerPrefs.SetInt("isFullscreen", isFullscreen ? 1 : 0);
        }
        
        public void SetResolution(int resolutionIndex)
        {
            _currentIndexOfResolution = resolutionIndex;
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            
            // On sauvegarde la résolution dans les PlayerPrefs
            PlayerPrefs.SetInt("resolutionWidth", resolution.width);
            PlayerPrefs.SetInt("resolutionHeight", resolution.height);
        }
    }
}

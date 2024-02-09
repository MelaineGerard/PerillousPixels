using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [Header("References")] 
        public AudioClip[] playlist;
        public AudioSource audioSource;
        
        private int _currentAudioIndex;

        private void Start()
        {
            // On défini le volume de l'audio source en fonction de la valeur stockée dans les préférences pour éviter les différences de volume si on recharge une scène
            audioSource.outputAudioMixerGroup.audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0));
            
            _currentAudioIndex = 0;
            audioSource.clip = playlist[_currentAudioIndex];
            audioSource.Play();
            
        }

        private void Update()
        {
            if (!audioSource.isPlaying)
            {
                PlayNextSong();
            }
        }

        private void PlayNextSong()
        {
            _currentAudioIndex++;
            if (_currentAudioIndex >= playlist.Length)
            {
                _currentAudioIndex = 0;
            }
            
            audioSource.clip = playlist[_currentAudioIndex];
            audioSource.Play();
        }
    }
}

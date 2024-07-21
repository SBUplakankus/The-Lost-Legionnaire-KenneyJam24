using System;
using UnityEngine;

namespace Systems
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Source")] 
        public static AudioManager instance;
        public AudioSource ambientSource;
        public AudioSource sfxSource;
        public AudioSource buildSource;
    
        [Header("Audio Clips")]
        public AudioClip ambience;
        public AudioClip material;
        public AudioClip collectible;
        public AudioClip build;
        public AudioClip complete;
        public AudioClip splash;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            ambientSource.clip = ambience;
            ambientSource.Play();
        }
        
        /// <summary>
        /// Play the Build SFX
        /// </summary>
        public void PlayBuild()
        {
            buildSource.clip = build;
            buildSource.Play();
        }
        
        /// <summary>
        /// Play the Splash SFX
        /// </summary>
        public void PlaySplash()
        {
            sfxSource.clip = splash;
            sfxSource.Play();
        }
        
        /// <summary>
        /// Play the Game End SFX
        /// </summary>
        public void PlayCompletion()
        {
            buildSource.clip = complete;
            buildSource.Play();
        }
        
        /// <summary>
        /// Play the Material SFX
        /// </summary>
        public void PlayMaterial()
        {
            sfxSource.clip = material;
            sfxSource.Play();
        }
        
        /// <summary>
        /// Play the Collectible SFX
        /// </summary>
        public void PlayCollectible()
        {
            sfxSource.clip = collectible;
            sfxSource.Play();
        }
    }
}

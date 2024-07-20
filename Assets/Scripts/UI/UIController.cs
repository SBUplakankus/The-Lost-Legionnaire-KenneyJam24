using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private ResourceTracker _resourceTracker;
        private const float TransitionTime = 0.2f;
        private const LeanTweenType LeanTypeIn = LeanTweenType.easeInCubic;
        private const LeanTweenType LeanTypeOut = LeanTweenType.easeOutCubic;
        
        [Header("Tutorial")]
        [SerializeField] private GameObject tutorial;
        [SerializeField] private Transform[] tutorialPositions;

        [Header("Materials")] 
        [SerializeField] private GameObject counterBox;
        [SerializeField] private TMP_Text materialCounter;
        [SerializeField] private TMP_Text valuableCounter;
        [SerializeField] private Transform[] materialPositions;

        [Header("Pause Menu")] 
        [SerializeField] private GameObject menuBlur;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Transform[] pausePositions;

        [Header("End Game")] 
        [SerializeField] private GameObject endGame;
        [SerializeField] private TMP_Text collectiblesGot;
        [SerializeField] private TMP_Text respawnsNeeded;
        [SerializeField] private TMP_Text timeTaken;
        [SerializeField] private Transform[] endPositions;
        

        private void Start()
        {
            _resourceTracker = ResourceTracker.instance;
            endGame.SetActive(false);
            pauseMenu.SetActive(false);
            menuBlur.SetActive(false);
            tutorial.SetActive(false);
            
            ShowMaterials();
            ShowTutorial();
        }

        private void Update()
        {
            materialCounter.text = _resourceTracker.currentMaterials.ToString();
            valuableCounter.text = _resourceTracker.collectiblesFound.ToString();
        }
        
        /// <summary>
        /// Show the Tutorial
        /// </summary>
        private void ShowTutorial()
        {
            tutorial.transform.position = tutorialPositions[1].position;
            tutorial.SetActive(true);
            LeanTween.moveX(tutorial, tutorialPositions[0].position.x, TransitionTime);
        }
        
        /// <summary>
        /// Hide the tutorial pop up
        /// </summary>
        public void HideTutorial()
        {
            tutorial.SetActive(false);
        }
        
        /// <summary>
        /// Show the Pause Menu
        /// </summary>
        public void ShowPauseMenu()
        {
            menuBlur.SetActive(true);
            pauseMenu.SetActive(true);
            LeanTween.moveY(pauseMenu, pausePositions[0].position.y, TransitionTime).setEase(LeanTypeIn);
        }
        
        /// <summary>
        /// Hide the Pause Menu
        /// </summary>
        public void HidePauseMenu()
        {
            menuBlur.SetActive(false);
            pauseMenu.SetActive(false);
        }
        
        /// <summary>
        /// Show the End Game Screen
        /// </summary>
        public void ShowEndGame()
        {
            menuBlur.SetActive(true);
            endGame.transform.position = endPositions[1].position;
            endGame.SetActive(true);
            LeanTween.moveY(endGame, endPositions[0].position.y, TransitionTime);
        }
        
        /// <summary>
        /// Show the Material Counters
        /// </summary>
        private void ShowMaterials()
        {
            counterBox.transform.position = materialPositions[1].position;
            LeanTween.moveX(counterBox, materialPositions[0].position.x, TransitionTime).setEase(LeanTypeIn);
        }
        
        /// <summary>
        /// Hide the Material Counters
        /// </summary>
        private void HideMaterials()
        {
            counterBox.transform.position = materialPositions[0].position;
            LeanTween.moveX(counterBox, materialPositions[1].position.x, TransitionTime).setEase(LeanTypeOut); 
        }
    }
}

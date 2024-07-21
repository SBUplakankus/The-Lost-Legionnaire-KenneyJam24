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
        private const float TransitionTime = 0.4f;
        private const LeanTweenType LeanTypeIn = LeanTweenType.easeOutBack;
        private const LeanTweenType LeanTypeOut = LeanTweenType.easeInBack;
        
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
        [SerializeField] private GameObject controls;
        private bool _menuOpen;

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
            counterBox.SetActive(true);
            _menuOpen = false;
        }

        private void Update()
        {
            materialCounter.text = _resourceTracker.currentMaterials.ToString();
            valuableCounter.text = _resourceTracker.collectiblesFound.ToString();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_menuOpen)
                {
                    ShowPauseMenu();
                    _menuOpen = true;
                }
                else
                {
                    HidePauseMenu();
                    _menuOpen = false;
                }
                
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                ShowTutorial();
            }
        }
        /// <summary>
        /// Show the Tutorial
        /// </summary>
        public void ShowTutorial()
        {
            tutorial.transform.position = tutorialPositions[1].position;
            tutorial.SetActive(true);
            LeanTween.moveX(tutorial, tutorialPositions[0].position.x, TransitionTime).setEase(LeanTypeIn);
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
        private void ShowPauseMenu()
        {
            HideTutorial();
            HideControls();
            counterBox.SetActive(false);
            menuBlur.SetActive(true);
            pauseMenu.transform.position = pausePositions[1].position;
            pauseMenu.SetActive(true);
            LeanTween.moveY(pauseMenu, pausePositions[0].position.y, TransitionTime).setEase(LeanTypeIn);
        }
        
        /// <summary>
        /// Hide the Pause Menu
        /// </summary>
        public void HidePauseMenu()
        {
            _menuOpen = false;
            menuBlur.SetActive(false);
            pauseMenu.SetActive(false);
            ShowMaterials();
        }
        
        /// <summary>
        /// Show the End Game Screen
        /// </summary>
        public void ShowEndGame()
        {
            SetEndGameStats();
            menuBlur.SetActive(true);
            counterBox.SetActive(false);
            endGame.transform.position = endPositions[1].position;
            endGame.SetActive(true);
            LeanTween.moveY(endGame, endPositions[0].position.y, TransitionTime).setEase(LeanTypeIn);
        }
        
        /// <summary>
        /// Get the End Game Screen Stats
        /// </summary>
        private void SetEndGameStats()
        {
            collectiblesGot.text = _resourceTracker.collectiblesFound switch
            {
                0 => "0%",
                1 => "20%",
                2 => "40%",
                3 => "60%",
                4 => "80%",
                5 => "100%",
                _ => collectiblesGot.text
            };
            
            respawnsNeeded.text = _resourceTracker.respawns.ToString();

            var timeTakenFloat = _resourceTracker.timeTaken;

            var minutes = (int)timeTakenFloat / 60;
            var seconds = (int)timeTakenFloat % 60;

            var timeFormatted = $"{minutes:00}:{seconds:00}";
            timeTaken.text = timeFormatted;
        }
        
        /// <summary>
        /// Show the Material Counters
        /// </summary>
        private void ShowMaterials()
        {
            counterBox.SetActive(true);
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

        public void ShowControls()
        {
            controls.SetActive(true);
        }

        public void HideControls()
        {
            controls.SetActive(false);
        }
    }
}

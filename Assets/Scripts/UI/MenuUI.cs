using System;
using UnityEngine;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {
        public GameObject creditsPanel;
        public Transform[] creditsPositions;
        public bool creditsOpen;
        
        private const float TransitionTime = 0.5f;
        private const LeanTweenType LeanTypeOut = LeanTweenType.easeOutBack;

        private void Start()
        {
            creditsPanel.SetActive(false);
        }

        public void CreditsButton()
        {
            if(creditsOpen)
                HideCredits();
            else
                ShowCredits();
        }

        private void ShowCredits()
        {
            creditsOpen = true;
            creditsPanel.transform.position = creditsPositions[1].position;
            creditsPanel.SetActive(true);
            LeanTween.moveX(creditsPanel, creditsPositions[0].position.x, TransitionTime).setEase(LeanTypeOut);
        }

        private void HideCredits()
        {
            creditsOpen = false;
            creditsPanel.SetActive(false);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

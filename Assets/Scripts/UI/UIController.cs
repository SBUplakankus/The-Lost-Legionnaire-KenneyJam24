using System;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        private ResourceTracker _resourceTracker;
        
        [Header("Tutorial")]
        [SerializeField] private GameObject tutorial;
        
        [Header("Materials")]
        [SerializeField] private TMP_Text materialCounter;

        [Header("End Game")] 
        [SerializeField] private GameObject endGame;
        [SerializeField] private TMP_Text collectiblesGot;
        [SerializeField] private TMP_Text respawnsNeeded;
        [SerializeField] private TMP_Text timeTaken;
        

        private void Start()
        {
            _resourceTracker = ResourceTracker.instance;
        }

        private void Update()
        {
            materialCounter.text = _resourceTracker.currentMaterials.ToString();
        }
    }
}

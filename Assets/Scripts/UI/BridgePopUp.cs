using System;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BridgePopUp : MonoBehaviour
    {
        [SerializeField] private int materialCost;
        [SerializeField] private int buildIndex;
        public TMP_Text materialCostText;
        public GameObject popUpCanvas;
        private ResourceTracker _resourceTracker;
        private BridgeManager _bridgeManager;
        private bool _readyToCraft;

        private void Start()
        {
            materialCostText.text = "Requires " + materialCost + " Materials";
            _bridgeManager = BridgeManager.instance;
            _resourceTracker = ResourceTracker.instance;
            popUpCanvas.transform.localScale = Vector3.zero;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E)) return;
            
            _resourceTracker.GetNextBuild();
                
            Debug.Log(_resourceTracker.currentMaterials);
            Debug.Log(materialCost);
            Debug.Log(_resourceTracker.buildCosts[buildIndex]);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
                LeanTween.scale(popUpCanvas, Vector3.one, 0.4f).setEase(LeanTweenType.easeOutBack);
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
                LeanTween.scale(popUpCanvas, Vector3.zero, 0.4f).setEase(LeanTweenType.easeInBack);
        }
    }
}

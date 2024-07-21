using System;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BridgePopUp : MonoBehaviour
    {
        public int materialCost;
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
            _readyToCraft = _resourceTracker.currentMaterials >= materialCost;

            if (!Input.GetKeyDown(KeyCode.E) || !_readyToCraft) return;
            
            Debug.Log(_resourceTracker.currentMaterials);
            Debug.Log(materialCost);
            _resourceTracker.currentMaterials -= materialCost;
            _bridgeManager.BuildBridge();
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

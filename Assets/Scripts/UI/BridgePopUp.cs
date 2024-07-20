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
            popUpCanvas.SetActive(false);
        }

        private void Update()
        {
            _readyToCraft = _resourceTracker.currentMaterials >= materialCost;

            if (!Input.GetKeyDown(KeyCode.E) || !_readyToCraft) return;
            
            _resourceTracker.currentMaterials -= materialCost;
            _bridgeManager.BuildBridge();
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Bridge Entered");
            if(other.gameObject.CompareTag("Player"))
                popUpCanvas.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Bridge Exited");
            if(other.gameObject.CompareTag("Player"))
                popUpCanvas.SetActive(false);
        }
    }
}

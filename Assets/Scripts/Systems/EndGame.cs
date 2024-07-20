using System;
using UnityEngine;
using UnityEngine.Events;

namespace Systems
{
    public class EndGame : MonoBehaviour
    {
        private bool _readyToEnd;
        [SerializeField] private GameObject popUp;
        [SerializeField] private UnityEvent endGameScreen;

        private void Start()
        {
            _readyToEnd = false;
            popUp.SetActive(false);
        }

        private void Update()
        {
            if (_readyToEnd && Input.GetKeyDown(KeyCode.E))
            {
                endGameScreen.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
                _readyToEnd = true;
                popUp.SetActive(true);
            
        }

        private void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
                _readyToEnd = false;
                popUp.SetActive(false);
            
        }
    }
}

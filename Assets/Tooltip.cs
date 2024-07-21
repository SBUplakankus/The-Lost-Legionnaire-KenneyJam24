using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public UIController ui;

    private void OnTriggerEnter(Collider other)
    {
        ui.ShowTutorial();
        Destroy(gameObject);
    }
}

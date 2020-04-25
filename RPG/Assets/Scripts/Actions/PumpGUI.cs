using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PumpGUI : MonoBehaviour
{

    public PumpController pumpController;

    public UnityEvent ShowInteractionButtons;
    public UnityEvent<PumpController> SharePumpController;


    public void Activate(PumpController pump)
    {
        pumpController = pump.GetComponent<PumpController>();
        ShowInteractionButtons.Invoke();
        SharePumpController.Invoke(pump);
    }
}

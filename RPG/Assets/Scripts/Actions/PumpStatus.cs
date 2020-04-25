using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PumpStatus : MonoBehaviour
{
    public Text waterInfo;
    public PumpController pump;

    private void Update()
    {
        waterInfo.text = string.Format("{0:0.0}", pump.waterlevel);
    }

    public void GetPumpController(PumpController pumpController)
    {
        pump = pumpController;
    }
}

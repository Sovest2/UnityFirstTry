using UnityEngine;
using UnityEngine.Events;

public class PumpController : MonoBehaviour
{
    public UnityEvent<PumpController> ToInteract;

    public int Level = 1;
    public float waterlevel = 0f;
    public int waterModifiler = 2;
    public float maxWater = 500;

    private void Update()
    {
        ChangeWaterLevel(waterModifiler * Time.deltaTime);
    }

    public void Interact()
    {
        ToInteract.Invoke(this);
    }

    public void ChangeWaterLevel(float change)
    {
        waterlevel += change;
        waterlevel = Mathf.Clamp(waterlevel, 0, maxWater);
    }

    public bool isEnoughWater(float water)
    {
        if (waterlevel - water >= 0) return true;
        return false;
    }
}

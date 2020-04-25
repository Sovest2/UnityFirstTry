using UnityEngine;
using UnityEngine.Events;



public class GroundController : MonoBehaviour
{
    public int cost = 250;
    public int status = 0;

    public float wateringLevel = 0f;
    public float progressLevel = 0f;

    public SeedData seedData;

    public GameObject interactionUI;

    public UnityEvent ToDryPiece;
    public UnityEvent ToWaterPiece;
    public UnityEvent<SeedData, GroundController> ToPlantSeed;
    public UnityEvent<GroundController> ToInteract;

    public void Update()
    {
        if ((wateringLevel < 45) &&(status == 2)) GetDryed();
        if ((wateringLevel >= 45) && (status == 1)) GetWatered();
        if (wateringLevel > 1 ) ChangeWateringLevel(-Time.deltaTime/10f);

        if (seedData != null)
        {
            ChangeProgressLevel((Time.deltaTime / seedData.GrowTime)*(wateringLevel/50));
        }
    }

    public void Interact()
    {
        ToInteract.Invoke(this);
    }

    public void ChangeWateringLevel(float change)
    {
        wateringLevel += change;
        wateringLevel = Mathf.Clamp(wateringLevel, 0f, 100f);
    }

    public void ChangeProgressLevel(float change)
    {
        progressLevel += change;
        progressLevel = Mathf.Clamp(progressLevel, 0f, 100f);
    }

    public void GetBought()
    {
        GetDryed();
        ChangeWateringLevel(25f);
    }

    public void GetDryed()
    {
        status = 1;
        ToDryPiece.Invoke();
    }

    public void GetWatered()
    {
        status = 2;
        ToWaterPiece.Invoke();
    }

    public void PlantSeed(SeedData seed)
    {
        ToPlantSeed.Invoke(seed, this);
    }




}

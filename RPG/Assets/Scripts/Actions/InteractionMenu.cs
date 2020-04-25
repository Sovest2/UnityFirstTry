using UnityEngine;
using UnityEngine.Events;

public class InteractionMenu : MonoBehaviour
{
    public UnityEvent ShowButtonBuy;
    public UnityEvent ShowButtonsInteract;
    public UnityEvent<GroundController, int> OnBuyGround;
    public UnityEvent<GroundController> ShareGroundController;
    public UnityEvent<GroundController> GatherGround;


    public PumpController pump;
    private GroundController groundController;

    public void Activate(GroundController ground)
    {
        groundController = ground;
        if (groundController)
        {
            if (groundController.status == 0)
            {
                ShowButtonBuy.Invoke();
            }
            else
            {
                ShowButtonsInteract.Invoke();
                ShareGroundController.Invoke(groundController);
            }
        }
    }

    public void BuyGround()
    {
        int cost = groundController.cost;
        OnBuyGround.Invoke(groundController, cost);
        if (groundController.status != 0)
        {
            ShowButtonsInteract.Invoke();
            ShareGroundController.Invoke(groundController);
        }
    }

    public void WaterGround()
    {
        if(pump.isEnoughWater(10))
        {
            groundController.ChangeWateringLevel(10f);
            pump.ChangeWaterLevel(-10f);
        }
    }

    public void PlantSeed(SeedData seedData)
    {
        groundController.PlantSeed(seedData);
    }

    public void GatherPlant()
    {
        if(groundController.progressLevel == 100f)
        {
            GatherGround.Invoke(groundController);
        }
    }

}

using UnityEngine;
using UnityEngine.Events;

public class EconomicManager : MonoBehaviour
{

    public int money = 500;

    public UnityEvent<string> OnMoneyChange;

    public void Start()
    {
        MoneySet(money);
    }


    public void MoneyChange(int wage)
    {
        money += wage;
        OnMoneyChange.Invoke(money.ToString());
    }

    public void MoneySet(int amount)
    {
        money = amount;
        OnMoneyChange.Invoke(money.ToString());
    }

    private bool IsEnoughMoney(int wage)
    {
        if (money - wage < 0) return false;
        return true;
    }

    public void BuyGround(GroundController ground,int cost)
    {
        if (ground.status == 0)
        {
            if (IsEnoughMoney(cost))
            {
                MoneyChange(-cost);
                ground.GetBought();
            }
        }
    }

    public void DoPlant(SeedData seed,GroundController ground)
    {
        int cost = seed.Cost;
        if (IsEnoughMoney(cost))
        {
            MoneyChange(-cost);
            ground.seedData = seed;
        }
    }

    public void DoGather(GroundController ground)
    {
        MoneyChange(ground.seedData.SellCost);
        ground.seedData = null;
        ground.progressLevel = 0f;
    }

}

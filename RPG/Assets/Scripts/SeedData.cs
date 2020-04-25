using UnityEngine;


[CreateAssetMenu(fileName = "New SeedData", menuName = "SeedData", order = 51)]
public class SeedData : ScriptableObject
{
    [SerializeField]
    private string seedName = "None";
    [SerializeField]
    private string description = "";
    [SerializeField]
    private Sprite icon = null;
    [SerializeField]
    private int cost = 0;
    [SerializeField]
    private int sellCost = 0;
    [SerializeField]
    private float growTime = 10000000f;

    public string SeedName
    {
        get
        {
            return seedName;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }
    }

    public int SellCost
    {
        get
        {
            return sellCost;
        }
    }

    public float GrowTime
    {
        get
        {
            return growTime;
        }
    }
}

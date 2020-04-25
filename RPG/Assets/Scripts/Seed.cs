using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Seed : MonoBehaviour
{
    [SerializeField]
    private SeedData seedData = null;

    public GameObject panel;
    public Image icon;
    public Text seedName;
    public Text seedCost;

    public UnityEvent<SeedData> DoPlant;

    private void Start()
    {
        panel.name = "slot"+seedData.SeedName;
        icon.sprite = seedData.Icon;
        seedName.text = seedData.SeedName;
        seedCost.text = seedData.Cost.ToString();
    }

    public void PlantThis()
    {
        DoPlant.Invoke(seedData);
    }
}

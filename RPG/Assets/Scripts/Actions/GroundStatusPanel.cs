using UnityEngine;
using UnityEngine.UI;

public class GroundStatusPanel : MonoBehaviour
{

    public Text waterInfo;
    public Text progressInfo;
    public Text plantInfo;
    public GroundController ground;


    // Update is called once per frame
    void Update()
    {
        if(ground)
        {
            waterInfo.text = string.Format("{0:0.0}%", ground.wateringLevel);
            progressInfo.text = string.Format("{0:0.0}%", ground.progressLevel);
            if (ground.seedData) plantInfo.text = ground.seedData.SeedName;
            else plantInfo.text = "None";
        }
    }

    public void GetGroundController(GroundController groundController)
    {
        ground = groundController;
    }
}

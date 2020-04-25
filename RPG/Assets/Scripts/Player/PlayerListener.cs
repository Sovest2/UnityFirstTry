using UnityEngine;
using UnityEngine.Events;

public class PlayerListener : MonoBehaviour
{
    [Header("Menu Items")]
    public GameObject HintPanel;
    public GameObject gameMenu;

    private GameObject interactedObject;


    public UnityEvent<GameObject> LockOnObject;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactedObject)
            {
                LockOnObject.Invoke(interactedObject);
                GroundController groundController = interactedObject.GetComponent<GroundController>();
                if (groundController) groundController.Interact();
                PumpController pumpController = interactedObject.GetComponent<PumpController>();
                if (pumpController) pumpController.Interact();
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        string triggerTag = other.gameObject.tag;
        if (triggerTag.Equals("Interactable"))
        {
            HintPanel.SetActive(true);
            interactedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HintPanel.SetActive(false);
        interactedObject = null;
    }

}

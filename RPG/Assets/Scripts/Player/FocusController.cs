using UnityEngine;

public class FocusController : MonoBehaviour
{

    [Header("Main Camera Selection")]
    public Transform mainCamera;

    [Header("Focus targets")]
    public Transform focusPlayer;
    public Transform focusTarget;

    [Header("Camera rotation, zoom")]
    public float rotationSpeed = 10f;
    public float minDistance = 5f;
    public float maxDistance = 25f;
    public float scrollSpeed = 15f;

    private float currentDistance = 5f;

    private float mouseX = -35f;
    private float mouseY = 180f;

    private void Start()
    {
        ResumeFocus();
    }

    private void Update()
    {   
        
        transform.position = Vector3.Lerp(transform.position, focusTarget.position, 0.05f);

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse Y")*rotationSpeed;
            mouseY += Input.GetAxis("Mouse X")*rotationSpeed;
            mouseX = Mathf.Clamp(mouseX, -65f, 0f);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        currentDistance = Mathf.Lerp(currentDistance, currentDistance - scroll, 0.5f);
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
        mainCamera.position = transform.position + Quaternion.Euler(mouseX, mouseY, 0f) * (currentDistance * -Vector3.back);
        mainCamera.LookAt(transform.position, Vector3.up);
    }

    public void SetFocus(GameObject focusOn)
    {
        focusTarget = focusOn.transform;
    }

    public void ResumeFocus()
    {
        focusTarget = focusPlayer;
    }
}

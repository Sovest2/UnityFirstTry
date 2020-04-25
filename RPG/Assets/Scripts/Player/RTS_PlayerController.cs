using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class RTS_PlayerController : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    private Animator agentAnimator;
    private Camera mainCam;

    private bool isControlBlocked = false;

    public UnityEvent<Vector3> onUpdateTarget;
    public UnityEvent OnTargetReached;

    private void Start()
    {
        agentAnimator = navMeshAgent.GetComponent<Animator>();
        mainCam = GetComponent<Camera>();
    }

    void Update()
    {
        agentAnimator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        if (!isControlBlocked)
        {


            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                OnTargetReached.Invoke();
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                {
                    Vector3 targetPosition = hitInfo.point;
                    UpdateTarget(targetPosition);
                }
            }
        }
    }

    private void UpdateTarget(Vector3 targetPosition)
    {
        navMeshAgent.destination = targetPosition;
        onUpdateTarget.Invoke(targetPosition);
    }

    public void BlockControl()
    {
        isControlBlocked = true;
        UpdateTarget(agentAnimator.transform.position);
    }

    public void UnblockControl()
    {
        isControlBlocked = false;
    }
}

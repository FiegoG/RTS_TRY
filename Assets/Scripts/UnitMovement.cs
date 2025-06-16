using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    public LayerMask ground;

    public bool isCommandToMove;

    DirectionIndicator directionIndicator;


    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();

        directionIndicator = GetComponent<DirectionIndicator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && UnitSelectionManager.Instance.unitSelected.Contains(gameObject))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                isCommandToMove = true;
                agent.SetDestination(hit.point);

                directionIndicator.DrawLine(hit);

            }
        }

        if (agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance)
        {
            isCommandToMove = false;
            
        }
    }
}

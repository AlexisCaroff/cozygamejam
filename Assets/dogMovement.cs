using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]


public class dogMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    { float speed = agent.velocity.magnitude;
        animator.SetFloat("Run", speed);
    }
    // Update is called once per frame
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}

using UnityEngine;
using UnityEngine.AI;
public class sheepBrain : MonoBehaviour
{
    
    Transform target;
    NavMeshAgent agent;
    public float lookRadius = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = playerManger.instance.Dog.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 direction = -(target.position - transform.position).normalized;
        if (distance <= lookRadius)
        {
            agent.SetDestination(transform.position+ direction);
        }
    }

   void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

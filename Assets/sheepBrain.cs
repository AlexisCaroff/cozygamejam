using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class sheepBrain : MonoBehaviour
{
    public float moveRadius = 10f; // Rayon dans lequel chercher une nouvelle destination
    public float minWaitTime = 5f; // Temps minimum entre les déplacements
    public float maxWaitTime = 10f; // Temps maximum entre les déplacements
    public AudioClip[] meeeSounds;
    private AudioSource audioSource;
    public float multiplicator = 6.0f;
    Transform targetDog;
    Transform targetBerger;
    Rigidbody bodyberger;
    playerController BergerMove;
    NavMeshAgent agent;
    public bool infield = false;
    public float lookRadius = 20f;
    Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetDog = playerManger.instance.Dog.transform;
        agent = GetComponent<NavMeshAgent>();
        targetBerger = playerManger.instance.Player.transform;
        BergerMove = playerManger.instance.Player.GetComponent<playerController>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(sheepstupid());
    }

    // Update is called once per frame
    void Update()
    {
            float speed = agent.velocity.magnitude;
            animator.SetFloat("runsheep", speed);
        
        float distancedog = Vector3.Distance(targetDog.position, transform.position);
        float distanceBerger = Vector3.Distance(targetBerger.position, transform.position);
        
        if (distancedog <= lookRadius && distanceBerger>2.0 && infield == false )
        {
           // Debug.Log("move away from dog");
            Vector3 direction = -(targetDog.position - transform.position).normalized;
            Vector3 Rundirection = new Vector3(direction.x * multiplicator, direction.y * multiplicator, direction.z * multiplicator);
            agent.speed = 10;
            agent.SetDestination(transform.position + Rundirection);
        }
        
        if (distanceBerger <= lookRadius / 2.0 && BergerMove.move.x != 0 && BergerMove.move.z != 0 && infield == false)
            {
            //  Debug.Log("move away from Berger");
                PlayRandomBee();
                Vector3 direction = -(targetBerger.position - transform.position).normalized;
                Vector3 Rundirection = new Vector3(direction.x * multiplicator, direction.y * multiplicator, direction.z * multiplicator);
                agent.SetDestination(transform.position + Rundirection);
            }
    }

   void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    IEnumerator sheepstupid()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            Vector3 randomPoint = GetRandomPoint();
            agent.speed = 5;
            agent.SetDestination(randomPoint);
        }
    }
    Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius; // Point aléatoire dans un rayon
        randomDirection += transform.position; // L'appliquer autour de l'agent

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, NavMesh.AllAreas))
        {
            return hit.position; // Retourne un point valide sur le NavMesh
        }

        return transform.position; // Si pas de point valide, ne bouge pas
    }
    void PlayRandomBee()
    {
        if (meeeSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, meeeSounds.Length); // Choix aléatoire
            audioSource.PlayOneShot(meeeSounds[randomIndex]); // Joue l'aboiement
        }
    }
}

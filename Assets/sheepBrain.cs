using UnityEngine;
using UnityEngine.AI;
public class sheepBrain : MonoBehaviour
{
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
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetDog = playerManger.instance.Dog.transform;
        agent = GetComponent<NavMeshAgent>();
        targetBerger = playerManger.instance.Player.transform;
        BergerMove = playerManger.instance.Player.GetComponent<playerController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancedog = Vector3.Distance(targetDog.position, transform.position);
        float distanceBerger = Vector3.Distance(targetBerger.position, transform.position);
        
        if (distancedog <= lookRadius && distanceBerger>2.0 && infield == false )
        {
           // Debug.Log("move away from dog");
            Vector3 direction = -(targetDog.position - transform.position).normalized;
            Vector3 Rundirection = new Vector3(direction.x * multiplicator, direction.y * multiplicator, direction.z * multiplicator);
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
    void PlayRandomBee()
    {
        if (meeeSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, meeeSounds.Length); // Choix aléatoire
            audioSource.PlayOneShot(meeeSounds[randomIndex]); // Joue l'aboiement
        }
    }
}

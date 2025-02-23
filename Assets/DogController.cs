using UnityEngine;


[RequireComponent(typeof(dogMovement))]
public class playercontroller : MonoBehaviour
{
    dogMovement movement;
    public AudioClip[] barkSounds; 
    private AudioSource audioSource;
    Camera cam;
    public LayerMask movementDogMask;
    void Start()
    {
        movement = GetComponent<dogMovement>();
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5000, movementDogMask))
            {
                PlayRandomBark();
                //Debug.Log("start deplacement to " + hit.collider.name + " " + hit.point);
                movement.MoveToPoint(hit.point);

            }
        }
    }
    void PlayRandomBark()
    {
        if (barkSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, barkSounds.Length); // Choix aléatoire
            audioSource.PlayOneShot(barkSounds[randomIndex]); // Joue l'aboiement
        }
    }
}
using UnityEngine;

public class bergerwalk : MonoBehaviour
{
    CharacterController characontrol;
    Transform playertransform;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characontrol = GetComponentInParent<CharacterController>();
        playertransform = transform.parent;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = characontrol.velocity.magnitude;
        //animator.SetFloat("Speedy", speed);

        Vector3 direction = playertransform.position + characontrol.velocity;
        //Debug.Log(characontrol.velocity);
        direction = new Vector3(direction.x, 0.0f , direction.z);
        //Debug.DrawLine(playertransform.position, playertransform.position + characontrol.velocity);
        if (speed > 0.5)
        {
            transform.LookAt( direction);
        }
        
        
    }
}

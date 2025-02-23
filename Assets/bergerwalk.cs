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

    void FaceTarget()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float speed = characontrol.velocity.magnitude;
        animator.SetFloat("Speedy", speed);

        Vector3 direction = (playertransform.position + characontrol.velocity.normalized);
        
        //Debug.Log(characontrol.velocity);
        direction = new Vector3(direction.x, playertransform.position.y , direction.z);
        //direction = direction.normalized;
        Debug.DrawLine(playertransform.position, direction);
        if (speed > 0.5)
        {
            transform.LookAt( direction);
        }
        
        
    }
}

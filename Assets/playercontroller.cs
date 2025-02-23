using UnityEngine;

public class playerController : MonoBehaviour
{

    CharacterController controller;
    public float speed = 5.0f;
    public Vector3 move;
    float gravity = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGrounded) {
            gravity = -0.8f;
                }
        else { gravity = 0; }
        move = new Vector3(Input.GetAxis("Horizontal"), gravity, Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * speed);
    }
}

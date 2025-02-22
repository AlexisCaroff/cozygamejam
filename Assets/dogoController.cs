using UnityEngine;


[RequireComponent(typeof(dogMovement))]
public class dogoController : MonoBehaviour
{
    dogMovement movement;
    Camera cam;
    public LayerMask movementDogMask;
    void Start()
    {
        movement = GetComponent<dogMovement>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
           // Debug.Log("start deplacement to ");
           /* if (Physics.Raycast(ray, out hit, 5000, movementDogMask))
            {
                //move dog
                Debug.Log("start deplacement to " + hit.collider.name + " " + hit.point);
                movement.MoveToPoint(hit.point);

            }*/
        }
    }
}
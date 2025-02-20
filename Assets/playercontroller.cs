using UnityEngine;


[RequireComponent(typeof(dogMovement))]
public class playercntroller : MonoBehaviour
{
    dogMovement movment;
    Camera cam;
    public LayerMask movementDogMask;
    void Start()
    {
        movment = GetComponent<dogMovement>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, movementDogMask))
            {
                //move dog
                Debug.Log("start deplacement to " + hit.collider.name + " " + hit.point);
                movment.MoveToPoint(hit.point);

            }
        }
    }
}

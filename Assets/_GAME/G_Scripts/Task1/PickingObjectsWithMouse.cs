using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class PickingObjectsWithMouse : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody heldObject;
    private Vector3 lastMousePosition;
    public float yOffset = 0.5f; // Adjust this value to set the height above the ground
    public LayerMask Collectible;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check for mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If ray hits an object with a Rigidbody, pick it up
            if (Physics.Raycast(ray, out hit))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    heldObject = rb;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    // Remember the initial mouse position relative to the object
                    lastMousePosition = hit.point - heldObject.position;
                }
            }
        }

        // Check for mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            if (heldObject != null)
            {
                // Release the held object
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject = null;
            }
        }

        // If an object is being held, move it with the mouse
        if (heldObject != null)
        {
            EventManager.EmitEvent("ObjectPicked");
            // Raycast from mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 targetPosition = ray.GetPoint(distance);
                // Adjust the target position to be higher than the ground
                targetPosition.y += yOffset;
                // Move the object to the target position with an offset
                heldObject.MovePosition(targetPosition - lastMousePosition);
            }
        }
    }
}

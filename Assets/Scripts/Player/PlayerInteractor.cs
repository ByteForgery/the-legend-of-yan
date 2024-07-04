using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Nico
public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1f;
    [SerializeField] private LayerMask interactableMask;

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("HEYHO MINECRAFT FREUNDE");

            // Ray erstellung in blickrichtung
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, interactionDistance, interactableMask);
            if (hit != false)
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Player player = GetComponent<Player>();
                    interactable.OnInteract(player);
                }
            }
        }
    }

    // Hilfe von Hakan
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * interactionDistance);
    }
}

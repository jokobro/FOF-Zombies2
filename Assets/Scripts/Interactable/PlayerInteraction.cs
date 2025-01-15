using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float playerInReach = 3f;
    Interactable currentInteractable;

    private void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.HandleInteraction();
        }
    }

    private void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //checkt of de collider in reach of de player
        if (Physics.Raycast(ray, out hit, playerInReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else // als new interactable niet aangezet is
                {
                    DisableCurrentInteractable();
                }
            }
        }
        else //als niks in ranche is
        {
            DisableCurrentInteractable();
        }
    }

    private void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        HUDcontroller.instance.EnableInteractionText(currentInteractable.message);
    }

    private void DisableCurrentInteractable()
    {
        HUDcontroller.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable = null;
        }
    }
}

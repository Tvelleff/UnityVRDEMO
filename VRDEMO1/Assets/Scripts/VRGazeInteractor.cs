using UnityEngine;
using Google.XR.Cardboard;

public class VRGazeInteractor : MonoBehaviour
{
    public float interactionDistance = 10f;

    private VRInteractiveObject currentObject;

    void Update()
    {
        Ray ray = new Ray(
            transform.position,
            transform.forward
        );

        RaycastHit hit;

        VRInteractiveObject newObject = null;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            newObject =
                hit.collider.GetComponent<VRInteractiveObject>();
        }

        if (newObject != currentObject)
        {
            if (currentObject != null)
            {
                currentObject.OnGazeExit();
            }

            currentObject = newObject;

            if (currentObject != null)
            {
                currentObject.OnGazeEnter();
            }
        }

        if (currentObject != null && Api.IsTriggerPressed)
        {
            currentObject.OnSelected();
        }
    }
}
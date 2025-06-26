// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class SnapToPosition : MonoBehaviour
// {
//     public Transform correctPosition;
//     private XRGrabInteractable grabInteractable;
//     private bool isLocked = false;

//     private void Start()
//     {
//         grabInteractable = GetComponent<XRGrabInteractable>();
//     }

//    /*  private void OnTriggerStay(Collider other)
// {
//     if (!isLocked && other.CompareTag("SnapZone"))
//     {
//         if (grabInteractable != null && grabInteractable.isSelected && other.transform == correctPosition)
//         {
//             SnapIntoPlace();

//             //Check to see if trigger is working. Idk if this is the correct "if" statement place
//             Debug.Log("Staying inside: " + other.name);

//         }
//     }
// } */

// //Test to see if grab check is ok- this fixed the "grab check" so things actually snapped into place
// private void OnTriggerStay(Collider other)
// {
//     if (!isLocked && other.CompareTag("SnapZone"))
//     {
//         if (other.transform == correctPosition)
//         {
//             SnapIntoPlace();
//         }
//     }
// }


// //his prints to the Console every time any collider enters the trigger. If you don’t see this log, then Unity isn't detecting the trigger event
// private void OnTriggerEnter(Collider other)
// {
//     Debug.Log("Triggered with: " + other.name); // Log the name of the object that triggered the snap zone

//     if (!isLocked && other.CompareTag("SnapZone"))
//     {
//         if (other.transform == correctPosition)
//         {
//             SnapIntoPlace();
//         }
//     }
// }



//     private void SnapIntoPlace()
//     {
//         isLocked = true;
//         transform.position = correctPosition.position;
//         transform.rotation = correctPosition.rotation;

//         grabInteractable.enabled = false;
//         GetComponent<Rigidbody>().isKinematic = true;

//         //check see if objs are snapping
//         Debug.Log("SNAPPING " + gameObject.name);

//     }
//}



using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToPosition : MonoBehaviour
{
    public Transform correctPosition; // Where this piece should snap
    private XRGrabInteractable grabInteractable;
    private bool isLocked = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

  private void OnTriggerEnter(Collider other)
{
    Debug.Log("Triggered with: " + other.name);

    if (!isLocked && other.CompareTag("SnapZone"))
    {
            // Match by name (or tag) instead of direct transform comparison
        //if (other.name == correctPosition.name)
        {
            SnapIntoPlace(); //just this now to make it less specific
        }
    }
}


    private void SnapIntoPlace()
    {
        isLocked = true;
        transform.position = correctPosition.position;
        transform.rotation = correctPosition.rotation;
        grabInteractable.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        Debug.Log(gameObject.name + " snapped correctly!");
    }
}

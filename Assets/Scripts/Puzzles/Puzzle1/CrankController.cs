using UnityEngine;
using Photon.Pun;

public class CrankController : MonoBehaviour
{
    [SerializeField]
    private Transform crankPivotTransform;

    [SerializeField]
    float rotationAngle = 5f;

    public bool IsRotating = false;

    [PunRPC]
    public void Interact()
    {
        
        IsRotating = true;
    }

    private void Update()
    {
        if (IsRotating)
        {
            crankPivotTransform.Rotate(Vector3.back * rotationAngle);
        }
    }

    [PunRPC]
    public void NotInteract()
    {
        IsRotating = false;
    }
}
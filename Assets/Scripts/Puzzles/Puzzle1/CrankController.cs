using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class CrankController : MonoBehaviour
{
    [SerializeField]
    private Transform crankPivotTransform;

    [SerializeField]
    float rotationDelta = 5f;

    [SerializeField]
    bool isActivated = false;

    [SerializeField]
    UnityEvent activateObject;

    [SerializeField]
    UnityEvent desactivateObject;


    // Start is called before the first frame update
    void Start()
    {
    }


    private void Update()
    {
    }

    [PunRPC]
    public void Interact()
    {

        crankPivotTransform.Rotate(Vector3.back * rotationDelta);
        isActivated = true;
        activateObject.Invoke();
    }

    [PunRPC]
    public void NotInteract()
    {
        isActivated = false;
        desactivateObject.Invoke();
    }


    public bool isMoving {
        get{
            return isActivated;
        }
}
}

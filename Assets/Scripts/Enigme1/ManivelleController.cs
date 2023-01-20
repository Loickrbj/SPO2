using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class ManivelleController : MonoBehaviour
{

    [SerializeField]
    private Transform manivellePivotTransform;

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

        manivellePivotTransform.Rotate(Vector3.back * rotationDelta);
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

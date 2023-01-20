using UnityEngine;
using Photon.Pun;

public class ManivelleController : MonoBehaviour
{

    [SerializeField]
    private Transform manivellePivotTransform;

    [SerializeField]
    float rotationDelta = 5f;

    [SerializeField]
    bool isActivated = false;

    [SerializeField]
    GameObject objectToActivate;
    // Start is called before the first frame update
    void Start()
    {
    }


    private void Update()
    {
        objectToActivate.SetActive(isActivated);
    }

    [PunRPC]
    public void Interact()
    {

        manivellePivotTransform.Rotate(Vector3.back * rotationDelta);
        isActivated = true;
    }

    [PunRPC]
    public void NotInteract()
    {
        isActivated = false;
    }
}

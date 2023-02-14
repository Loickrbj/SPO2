using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class LeverController : MonoBehaviourPun
{
    [SerializeField]
    private UnityEvent activateObject;

    [SerializeField]
    private UnityEvent desactivateObject;

    private Animator leverAnimator;

    public bool IsActivated;

    [SerializeField]
    LayerMask layerMask;

    private void Start()
    {
        leverAnimator = GetComponentInChildren<Animator>();
        IsActivated = leverAnimator.GetBool("IsActive");
    }

    [PunRPC]
    public void Interact()
    {
            IsActivated = true;
            leverAnimator.SetBool("IsActive", true);
            activateObject.Invoke();
    }

    [PunRPC]
    public void NotInteract()
    {
            IsActivated = false;
            leverAnimator.SetBool("IsActive", false);
            desactivateObject.Invoke();
    }
}

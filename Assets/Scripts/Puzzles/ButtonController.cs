using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class ButtonController : MonoBehaviourPun
{
    [SerializeField]
    private UnityEvent activateObject;

    [SerializeField]
    private UnityEvent desactivateObject;

    [SerializeField]
    private AudioSource audioSource;

    private Animator buttonAnimator;

    public bool IsActivated;

    [SerializeField]
    private LayerMask layerMask;

    private void Start()
    {
        buttonAnimator = GetComponentInChildren<Animator>();
        IsActivated = buttonAnimator.GetBool("IsActive");
    }

    [PunRPC]
    public void Interact()
    {
        if (!buttonAnimator.GetBool("IsActive"))
        {
            audioSource.Play();
            IsActivated = true;
            buttonAnimator.SetBool("IsActive", true);
            activateObject.Invoke();
        }
        else if (buttonAnimator.GetBool("IsActive"))
        {
            audioSource.Play();
            IsActivated = false;
            buttonAnimator.SetBool("IsActive", false);
            desactivateObject.Invoke();
        }
    }
}

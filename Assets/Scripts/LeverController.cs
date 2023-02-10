using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class LeverController : MonoBehaviourPun
{

    [SerializeField]
    private UnityEvent activateObject;

    [SerializeField]
    private UnityEvent desactivateObject;

    private Animator leverAnimator;

    private bool leverActivated;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    float maxDistanceRay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        leverAnimator = GetComponentInChildren<Animator>();
        leverActivated = leverAnimator.GetBool("Activate");
    }

    // Update is called once per frame
    void Update()
    {
        //Ray MiddleScreenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //RaycastHit hit;
        //if (Physics.Raycast(MiddleScreenRay, out hit, maxDistanceRay, layerMask))
        //{
        //    print(hit.transform.name);
        //    if (hit.transform.parent.gameObject == gameObject)
        //    {
        //        if (Input.GetKeyDown(KeyCode.E) && !leverAnimator.GetBool("Activate"))
        //        {
        //            leverActivated = true;
        //            leverAnimator.SetBool("Activate", true);
        //            objectToActivate.SetActive(true);
        //        }
        //        else if (Input.GetKeyDown(KeyCode.E) && leverAnimator.GetBool("Activate"))
        //        {
        //            leverActivated = false;
        //            leverAnimator.SetBool("Activate", false);
        //            objectToActivate.SetActive(false);
        //        }
        //    }
            
        //}
    }
    [PunRPC]
    public void Interact()
    {
        

        if (!leverAnimator.GetBool("Activate"))
        {
            leverActivated = true;
            leverAnimator.SetBool("Activate", true);
            activateObject.Invoke();
        }
        else
        {
            leverActivated = false;
            leverAnimator.SetBool("Activate", false);
            desactivateObject.Invoke();
        }
    }

    public bool IsActivated
    {
        get
        {
            return leverActivated;
        }
    }
}

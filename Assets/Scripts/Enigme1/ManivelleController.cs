using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManivelleController : MonoBehaviour
{

    [SerializeField]
    private Transform manivellePivotTransform;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    float maxDistanceRay = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray MiddleScreenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(MiddleScreenRay, maxDistanceRay, layerMask))
        {
            if (Input.GetButton("E"))
            {

            }
        }
    }
}

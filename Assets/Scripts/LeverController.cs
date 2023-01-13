using UnityEngine;

public class LeverController : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToActivate;

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
        Ray MiddleScreenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(MiddleScreenRay, maxDistanceRay, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E) && !leverAnimator.GetBool("Activate"))
            {
                leverActivated = true;
                leverAnimator.SetBool("Activate", true);
                objectToActivate.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && leverAnimator.GetBool("Activate"))
            {
                leverActivated = false;
                leverAnimator.SetBool("Activate", false);
                objectToActivate.SetActive(false);
            }
        }
    }
}

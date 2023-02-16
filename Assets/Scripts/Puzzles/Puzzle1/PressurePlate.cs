using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Material referenceMaterial;
    [SerializeField] private AudioSource onAudioSource;
    [SerializeField] private AudioSource offAudioSource;
    [SerializeField] private Animator animator;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color deactivatedColor;
    [SerializeField] private Color notEnoughColor;
    [SerializeField] private Color tooManyColor;
    [SerializeField] private Color activatedColor;
    private int playersCount = 0;
    public int NumberOfPlayersRequired = 0;
    public bool IsActivated;

    private void Start()
    {
        meshRenderer.material = new Material(referenceMaterial);
        meshRenderer.material.color = deactivatedColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onAudioSource.Play();
            animator.SetBool("IsActive", true);

            playersCount++;
            CheckCondition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            offAudioSource.Play();
            animator.SetBool("IsActive", false);

            playersCount--;
            CheckCondition();
        }
    }

    private void CheckCondition()
    {
        if (playersCount != 0 && playersCount < NumberOfPlayersRequired)
        {
            meshRenderer.material.color = notEnoughColor;
            IsActivated = false;
        }
        else if (playersCount == NumberOfPlayersRequired)
        {
            meshRenderer.material.color = activatedColor;
            IsActivated = true;
        }
        else if (playersCount >= NumberOfPlayersRequired)
        {
            meshRenderer.material.color = tooManyColor;
            IsActivated = false;
        }
        else
        {
            meshRenderer.material.color = deactivatedColor;
            IsActivated = false;
        }
    }

    public void SetPressureCondition(int value)
    {
        NumberOfPlayersRequired = value;
    }
}

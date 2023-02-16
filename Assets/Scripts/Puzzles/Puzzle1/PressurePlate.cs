using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Material referenceMaterial;
    [SerializeField] private AudioSource onAudioSource;
    [SerializeField] private AudioSource offAudioSource;
    private MeshRenderer meshRenderer;
    private int playersCount = 0;
    public int NumberOfPlayersRequired = 0;
    public bool IsActivated;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(referenceMaterial);
        meshRenderer.material.color = Color.gray;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onAudioSource.Play();

            playersCount++;
            CheckCondition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            offAudioSource.Play();

            playersCount--;
            CheckCondition();
        }
    }

    private void CheckCondition()
    {
        if (playersCount != 0 && playersCount < NumberOfPlayersRequired)
        {
            meshRenderer.material.color = Color.yellow;
            IsActivated = false;
        }
        else if (playersCount == NumberOfPlayersRequired)
        {
            meshRenderer.material.color = Color.green;
            IsActivated = true;
        }
        else if (playersCount >= NumberOfPlayersRequired)
        {
            meshRenderer.material.color = Color.red;
            IsActivated = false;
        }
        else
        {
            meshRenderer.material.color = Color.gray;
            IsActivated = false;
        }
    }

    public void SetPressureCondition(int value)
    {
        NumberOfPlayersRequired = value;
    }
}

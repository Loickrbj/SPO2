using UnityEngine;

namespace SPO2.Enigme1
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private int pressureCondition = 0;
        [SerializeField] private Material referenceMaterial;
        private MeshRenderer meshRenderer;
        private int playersCount;

        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material = new Material(referenceMaterial);
            meshRenderer.material.color = Color.gray;
            CheckCondition();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playersCount++;
                CheckCondition();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playersCount--;
                CheckCondition();
            }
        }

        private void CheckCondition()
        {
            if (playersCount != 0 && playersCount < pressureCondition)
                meshRenderer.material.color = Color.yellow;
            else if (playersCount == pressureCondition)
                meshRenderer.material.color = Color.green;
            else if (playersCount >= pressureCondition)
                meshRenderer.material.color = Color.red;
            else
                meshRenderer.material.color = Color.gray;
        }

        public void SetPressureCondition(int value)
        {
            pressureCondition = value;
        }
    }
}


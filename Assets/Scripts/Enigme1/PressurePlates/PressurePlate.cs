using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Enigme1
{
    public class PressurePlate : MonoBehaviour
    {

        #region Attributes
        [SerializeField] private int pressureCondition = 0;
        [SerializeField] private Material material;

        private int playersCount;
        #endregion

        void Start()
        {
            material.color = Color.gray;
            CheckCondition();
        }

        // Update is called once per frame
        void Update()
        {

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
                material.color = Color.yellow;
            else if (playersCount == pressureCondition)
                material.color = Color.green;
            else if (playersCount >= pressureCondition)
                material.color = Color.red;
            else
                material.color = Color.gray;
        }

        public void SetPressureCondition(int value)
        {
            pressureCondition = value;
        }
    }
}


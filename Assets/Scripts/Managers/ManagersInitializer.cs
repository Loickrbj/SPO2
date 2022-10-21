using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Managers
{
    public class ManagersInitializer : MonoBehaviour
    {
        protected static GameManager gameManager;
        private void Awake()
        {
            ManagersInitializer[] initializers = FindObjectsOfType<ManagersInitializer>();
            if (initializers.Length > 1)
                Destroy(this.gameObject);
            else
            {
                if (gameManager == null)
                {
                    GameObject o = new GameObject("_GameManager_<" + typeof(GameManager).ToString() + ">");
                    gameManager = o.AddComponent<GameManager>();
                    o.transform.parent = this.transform;
                }

                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}


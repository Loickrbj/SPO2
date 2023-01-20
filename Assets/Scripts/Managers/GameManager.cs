using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Properties 

        public static GameManager instance => m_instance;
        public static GameData GameData { get; private set; }
        public static GameObject Player => player;

        #endregion

        #region Attributes
        protected GameManagerSettings settings;

        protected static GameManager m_instance;

        protected static GameObject player;


        #endregion

        public void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            settings = (GameManagerSettings)Resources.Load("GameManagerSettings", typeof(GameManagerSettings));

            GameData = settings.gameData;
        }

        private void Start()
        {
            if(PlayerManager.localPlayer == null)
                player = PhotonNetwork.Instantiate(GameData.Player.characterPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
        }

        
        void Update()
        {

        }
    }
}


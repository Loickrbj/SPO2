using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Managers
{
    public class GameManager : SingleBehaviour<GameManager, GameManagerSettings>
    {
        public static GameData GameData { get; private set; }

        private GameObject player; 
        public override void Awake()
        {
            base.Awake();

            settings = (GameManagerSettings)Resources.Load("ManagersSettings/GameManagerSettings", typeof(GameManagerSettings));

            GameData = settings.gameData;
        }

        private void Start()
        {
            player = Instantiate(GameData.Player.characterPrefab);
        }

        
        void Update()
        {

        }
    }
}


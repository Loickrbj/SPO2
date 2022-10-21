using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Managers
{
    //[CreateAssetMenu(fileName = "GameManagerSettings", menuName = "SPO2/GameManagerSettings")]
    public class GameManagerSettings : ScriptableObject
    {
        [System.Serializable]

        public class RoomSettings
        {
            public int roomSize;
            public bool onlineMode = false;
        }

        public GameData gameData;

        [Space]
        public RoomSettings roomSettings = new RoomSettings();
    }
}


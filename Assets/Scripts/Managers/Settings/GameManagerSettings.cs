using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Managers
{
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


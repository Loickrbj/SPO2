using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2
{
    //[CreateAssetMenu(fileName = "GameData", menuName = "SPO2/GameData")]
    public class GameData : ScriptableObject
    {
        [System.Serializable]
        public class PlayerData
        {
            public GameObject characterPrefab;
        }

        public PlayerData Player = new PlayerData();
    }
}


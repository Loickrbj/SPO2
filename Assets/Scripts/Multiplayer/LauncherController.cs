using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LauncherController : MonoBehaviourPunCallbacks
{
    [Header("Connection")]
    public bool isOffline = false;
    [Space(10)]
    public bool autoConnect = true;
    [Space(10)]
    public TextMeshProUGUI textInfo;
    public byte maxPlayerPerRoom = 5;
    public string gameVersion = "1.0";
    public string pseudo = "Coquinou";
    public bool isConnecting = false;
    private int SelectedSceneIndex = 1;

    [Serializable]
    public struct SceneObject
    {
        [HideInInspector]
        public string sName;
        [NonSerialized]
        public string Path;
    }

    [Space(5)]
    [Header("Levels to launch")]
    [Space(5)]
    public SceneObject[] scenes;

    private void Awake()
    {
        if (isOffline) PhotonNetwork.OfflineMode = true;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (autoConnect)
            Connect();
    }

    private void Update()
    {
        textInfo.text = PhotonNetwork.NetworkClientState.ToString();
    }

    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        PhotonNetwork.NickName = pseudo;
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            //PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.JoinOrCreateRoom("Game", new RoomOptions { MaxPlayers = maxPlayerPerRoom }, TypedLobby.Default);
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.JoinOrCreateRoom("Game", new RoomOptions { MaxPlayers = maxPlayerPerRoom }, TypedLobby.Default);
            isConnecting = false;
        }

        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom("Game", new RoomOptions { MaxPlayers = maxPlayerPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        Debug.Log("Connected to the room: " + PhotonNetwork.CurrentRoom.Name + " Player(s) online: " + PhotonNetwork.CurrentRoom.PlayerCount + " Master: " + PhotonNetwork.IsMasterClient + " is " + PhotonNetwork.MasterClient.NickName);
        if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel(scenes[SelectedSceneIndex].sName);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
        }
    }


    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
        }
    }

    public void ConnectUser()
    {
        Connect();
    }

    public void ChangePseudo(TMPro.TMP_InputField input)
    {
        pseudo = input.text;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LauncherController))]
public class LauncherEditor : Editor
{
    LauncherController t;
    SerializedObject GetTarget;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        t = (LauncherController)target;
        GetTarget = new SerializedObject(t);

        GetTarget.Update();

        if (GUILayout.Button("Refresh Scenes"))
        {
            UpdateScenes();
        }

        SerializedProperty scenes = serializedObject.FindProperty("scenes");

        scenes.isExpanded = true;

        serializedObject.ApplyModifiedProperties();

    }

    void UpdateScenes()
    {
        List<LauncherController.SceneObject> scenes = new List<LauncherController.SceneObject>();

        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            if (EditorBuildSettings.scenes[i].enabled)
            {
                try
                {
                    var path = EditorBuildSettings.scenes[i].path;
                    LauncherController.SceneObject val = new LauncherController.SceneObject();

                    val.sName = System.IO.Path.GetFileNameWithoutExtension(path);
                    val.Path = path;

                    scenes.Add(val);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        t.scenes = scenes.ToArray();
    }
}
#endif
